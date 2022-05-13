// By Wojciech "HyeroDrimm" Wroñski

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shootingStrength = 5f;
    public float lifeTime = 5f;
    public LayerMask affectedLayers;
    [HideInInspector] public Vector3 shootingDirection;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(shootingDirection * shootingStrength);

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((affectedLayers.value & (1 << collision.gameObject.layer)) != 0 && collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.DealDamage();
            Destroy(gameObject);
        }
    }
}
