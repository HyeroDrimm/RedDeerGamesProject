// By Wojciech "HyeroDrimm" Wroński

using System.Collections.Generic;
using UnityEngine;

public class BulletToggleGroup : MonoBehaviour
{
    private List<BulletToggle> children = new List<BulletToggle>();
    private BulletToggle currentActive;

    public void AddChild(BulletToggle child)
    {
        if (children.Contains(child) == false)
        {
            children.Add(child);

            child.secretOnButtonTurnOn += OnToggle;

            if (child.currentState)
                currentActive = child;
        }
    }

    private void OnToggle(BulletToggle newToggle)
    {
        if (currentActive != newToggle)
        {
            currentActive.currentState = false;
            currentActive.onButtonTurnOff.Invoke();
            currentActive.secretOnButtonTurnOff?.Invoke(newToggle);

            currentActive = newToggle;
        }
    }
}
