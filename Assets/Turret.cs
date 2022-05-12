using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float secBetweenShoot = 5f;
    [SerializeField] private float shootingStrength = 5f;
    [SerializeField] private Transform shootingPoint;


    private float counter = 0;

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter >= secBetweenShoot)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = shootingPoint.position;
            bullet.shootingStrength = shootingStrength;
            bullet.shootingDirection = shootingPoint.forward;

            counter -= secBetweenShoot;
        }
    }
}
