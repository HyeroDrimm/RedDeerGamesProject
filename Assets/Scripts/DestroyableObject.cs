// By Wojciech "HyeroDrimm" Wroński

using UnityEngine;

public class DestroyableObject : MonoBehaviour, IBulletActivated
{
    public void BulletActivate()
    {
        Destroy(gameObject);
    }
}
