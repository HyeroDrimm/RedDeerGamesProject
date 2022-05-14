// By Wojciech "HyeroDrimm" Wroński

using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class BulletToggle : MonoBehaviour, IBulletActivated
{
    public bool currentState = false;
    public BulletToggleGroup buttonGroup;

    public UnityEvent<bool> onBulletHit;
    public UnityEvent onButtonTurnOn;
    public UnityEvent onButtonTurnOff;

    public Action<BulletToggle> secretOnButtonTurnOn;
    public Action<BulletToggle> secretOnButtonTurnOff;


    private void Awake()
    {
        buttonGroup?.AddChild(this);
    }

    public void BulletActivate() 
    {
        if (buttonGroup == null || (buttonGroup != null && currentState == false))
        {
            onBulletHit.Invoke(currentState);

            currentState = !currentState;

            if (currentState)
            {
                secretOnButtonTurnOn?.Invoke(this);
                onButtonTurnOn.Invoke();
            }
            else
            {
                secretOnButtonTurnOff?.Invoke(this);
                onButtonTurnOff.Invoke();
            }
        }
    }
}
