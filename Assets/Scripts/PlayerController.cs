using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [HideInInspector] public SavePoint lastCheckpoint;
    private CharacterController characterController;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
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
