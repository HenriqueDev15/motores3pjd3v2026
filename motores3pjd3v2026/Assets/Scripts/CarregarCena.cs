using UnityEngine;

public class CarregarCena : MonoBehaviour
{
    public void IniciarJogo()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Gameplay);

        GameManager.Instance.ChangeScene("GetStarted_Scene");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}