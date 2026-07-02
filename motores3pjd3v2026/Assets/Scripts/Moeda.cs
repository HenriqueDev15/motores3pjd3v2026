using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Rotação")]
    public float rotationSpeed = 180f;

    private void Update()
    {
        // Gira continuamente no eixo Z
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCoins player = other.GetComponent<PlayerCoins>();

            if (player != null)
            {
                player.CollectCoin();
            }

            Destroy(gameObject);
        }
    }
}