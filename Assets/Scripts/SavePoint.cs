using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private bool isStartSpawn = false;

    public Transform SpawnPosition { get => spawnPosition; set => spawnPosition = value; }

    private void Awake()
    {
        if (isStartSpawn)
        {
            FindObjectOfType<PlayerController>().LastCheckpoint = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().LastCheckpoint = this;
        }
    }
}
