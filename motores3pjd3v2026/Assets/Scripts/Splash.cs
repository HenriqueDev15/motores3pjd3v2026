
using UnityEngine;

public class TelaInicial : MonoBehaviour
{
    void Start()
    {
        Invoke("IrParaOMenu", 2f);
    }

    void IrParaOMenu()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.MenuPrincipal);

        GameManager.Instance.ChangeScene("Menu");
    }
}