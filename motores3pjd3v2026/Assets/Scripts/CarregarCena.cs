using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarCena : MonoBehaviour
{
    public void IniciarJogo()
    {
        
        GameManager.Instancia.CarregarCena("GetStarted_Scene");
    }

    public void Sair()
    {
        GameManager.Instancia.SairJogo();
    }
}