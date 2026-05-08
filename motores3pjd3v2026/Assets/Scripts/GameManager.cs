using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
  
    public string gameState;

    void Start()
    {
      
        gameState = "Starting";
        Debug.Log("Game State: " + gameState);

        SceneManager.LoadScene("Splash");
    }

  
    public void ChangeScene(string GetStarted_Scene )
    {
        SceneManager.LoadScene(GetStarted_Scene);
    }
}