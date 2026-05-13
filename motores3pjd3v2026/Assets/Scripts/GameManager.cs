using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance;
    
    
    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public GameState currentState;

    private void Awake()
    {
      
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
       
        ChangeState(GameState.Iniciando);

     
        SceneManager.LoadScene("Splash");
    }

   
    

    public void ChangeState(GameState newState)
    {
        currentState = newState;

        Debug.Log("Game State: " + currentState);
    }

    

    public void ChangeScene(string sceneName)
    {
        Debug.Log("Carregando cena: " + sceneName);

        SceneManager.LoadScene(sceneName);
    }
}