// By Wojciech "HyeroDrimm" Wroñski

using StarterAssets;
using UnityEngine;

public class ChestShooter : MonoBehaviour
{
    [SerializeField] private MainChannel mainChannel;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float secBetweenShoot = 5f;
    [SerializeField] private float shootingStrength = 5f;
    [SerializeField] private Transform shootingPoint;

    private float counter = 0;
    private StarterAssetsInputs input;

    private void Awake()
    {
        input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if (input.attack && counter >= secBetweenShoot)
        {
            mainChannel.RaiseShootNumberIncrement();
            ShootBullet();
            counter = 0;
        }
    }

    private void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = shootingPoint.position;
        bullet.shootingStrength = shootingStrength;
        bullet.shootingDirection = shootingPoint.forward;
    }
}
