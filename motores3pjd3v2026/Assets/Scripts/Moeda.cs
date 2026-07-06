using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Rotação")]
    public float rotationSpeed = 180f;

   
    public static event Action OnCoinCollected;

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            OnCoinCollected?.Invoke();

            Destroy(gameObject);
        }
    }
}