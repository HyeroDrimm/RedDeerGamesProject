// By Wojciech "HyeroDrimm" Wroñski

using StarterAssets;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ThirdPersonController))]
public class PlayerController : MonoBehaviour, IDamageable
{
    [HideInInspector] public SavePoint lastCheckpoint;
    private CharacterController characterController;
    private ThirdPersonController thirdPersonController;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReturnToLastCheckpoint();
        }
    }

    public void ReturnToLastCheckpoint()
    {
        if (lastCheckpoint != null)
        {
            characterController.enabled = false;
            transform.position = lastCheckpoint.SpawnPosition.position;
            transform.rotation = lastCheckpoint.SpawnPosition.rotation;
            characterController.enabled = true;
        }
    }

    public void DealDamage()
    {
        ReturnToLastCheckpoint();
    }
}
