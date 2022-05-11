using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SavePoint lastCheckpoint;
    private CharacterController characterController;

    public SavePoint LastCheckpoint { get => lastCheckpoint; set => lastCheckpoint = value; }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (lastCheckpoint != null)
            {
                characterController.enabled = false;
                transform.position = lastCheckpoint.SpawnPosition.position;
                transform.rotation = lastCheckpoint.SpawnPosition.rotation;
                characterController.enabled = true;
            }
        }
    }
}
