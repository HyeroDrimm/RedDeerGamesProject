// By Wojciech "HyeroDrimm" Wroński

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class BulletButton : MonoBehaviour, IBulletActivated
{
    public UnityEvent onBulletHit;

    public void BulletActivate()
    {
        onBulletHit.Invoke();
    }
}
