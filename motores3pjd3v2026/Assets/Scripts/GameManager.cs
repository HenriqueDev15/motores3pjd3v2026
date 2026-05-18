using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    public enum EstadoJogo
    {
        Iniciando,
        Menu,
        Gameplay
    }

    public EstadoJogo estadoAtual;
    private PlayerInput entradaJogador;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += AoCarregarCena;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AoCarregarCena;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Splash")
        {
            AtualizarEstadoPorCena("Splash");
            AlocarInput();
        }
        else
        {
            CarregarCena("Splash");
        }
    }

    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    private void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        AtualizarEstadoPorCena(cena.name);
        AlocarInput();
    }

    private void AtualizarEstadoPorCena(string nomeCena)
    {
        if (nomeCena == "Splash")
        {
            MudarEstado(EstadoJogo.Iniciando);
        }
        else if (nomeCena == "Menu")
        {
            MudarEstado(EstadoJogo.Menu);
        }
        else if (nomeCena == "GetStarted_Scene")
        {
            MudarEstado(EstadoJogo.Gameplay);
        }
    }

    public void MudarEstado(EstadoJogo novoEstado)
    {
        estadoAtual = novoEstado;
        Debug.Log("Estado atual alterado para: " + estadoAtual);
    }

    public void AlocarInput()
    {
        entradaJogador = FindFirstObjectByType<PlayerInput>();
        if (entradaJogador != null)
        {
            Debug.Log("Player Input encontrado na cena atual!");
        }
        else
        {
            Debug.Log("Nenhum Player Input encontrado nesta cena.");
        }
    }

    public void SairJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}