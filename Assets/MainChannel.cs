using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MainChannel", menuName = "ScriptableObjects/Channel/MainChannel", order = 1)]
public class MainChannel : ScriptableObject
{
    public Action onJumpNumberIncrement;
    public Action onShootNumberIncrement;

    public void RaiseJumpNumberIncrement()
    {
        onJumpNumberIncrement?.Invoke();
    }
    public void RaiseShootNumberIncrement()
    {
        onShootNumberIncrement?.Invoke();
    }
}
