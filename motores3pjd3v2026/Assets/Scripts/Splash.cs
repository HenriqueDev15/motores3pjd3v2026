
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    void Start()
    {
        Invoke("IrParaMenu", 2f);
    }

    void IrParaMenu()
    {
        
        GameManager.Instancia.CarregarCena("Menu");
    }
}