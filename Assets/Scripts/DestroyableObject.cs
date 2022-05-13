// By Wojciech "HyeroDrimm" Wroński

using UnityEngine;

public class DestroyableObject : MonoBehaviour, IDamageable
{
    public void DealDamage()
    {
        Destroy(gameObject);
    }
}
