using UnityEngine;
using UnityEngine.SceneManagement; 

public class TelaInicial : MonoBehaviour
{
    void Start()
    {
        Invoke("IrParaOMenu", 2f);
    }

    void IrParaOMenu()
    {
       
        SceneManager.LoadScene("Menu");
    }
}