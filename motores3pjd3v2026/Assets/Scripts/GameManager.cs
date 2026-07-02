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
        // Se estiver carregada, fecha a GUI antes de trocar de cena
        if (SceneManager.GetSceneByName("GUI").isLoaded)
        {
            SceneManager.UnloadSceneAsync("GUI");
        }

        // Carrega a cena principal
        SceneManager.LoadScene(nomeCena);

        // Se for a Gameplay, carrega também a GUI
        if (nomeCena == "GetStarted_Scene")
        {
            SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
        }
    }

    private void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        AtualizarEstadoPorCena(cena.name);
        AlocarInput();
    }

    private void AtualizarEstadoPorCena(string nomeCena)
    {
        switch (nomeCena)
        {
            case "Splash":
                MudarEstado(EstadoJogo.Iniciando);
                break;

            case "Menu":
                MudarEstado(EstadoJogo.Menu);
                break;

            case "GetStarted_Scene":
                MudarEstado(EstadoJogo.Gameplay);
                break;
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