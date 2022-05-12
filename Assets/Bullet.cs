using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shootingStrength = 5f;
    public float lifeTime = 5f;
    public Vector3 shootingDirection;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(shootingDirection * shootingStrength);

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            var player = collision.transform.GetComponent<PlayerController>();
            player.ReturnToLastCheckpoint();
            Destroy(gameObject);
        }
        if (collision.transform.CompareTag("Destroyable"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
