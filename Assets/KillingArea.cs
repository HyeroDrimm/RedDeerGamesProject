// By Wojciech "HyeroDrimm" Wroński

using UnityEngine;

public class KillingArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController playerController))
        {
            playerController.ReturnToLastCheckpoint();
        }
    }
}
