using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;

    public Transform SpawnPosition { get => spawnPosition; set => spawnPosition = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().LastCheckpoint = this;
        }
    }
}
