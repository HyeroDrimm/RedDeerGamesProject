using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField] private MainChannel mainChannel;

    [SerializeField] private TMP_Text jumpCountText;
    [SerializeField] private TMP_Text shootCountText;
    [SerializeField] private TMP_Text timeCountText;

    private int jumpCount = 0;
    private int shootCount = 0;

    private void Awake()
    {
        mainChannel.onJumpNumberIncrement += OnJumpNumberIncrement;
        mainChannel.onShootNumberIncrement += OnShootNumberIncrement;
    }

    private void OnJumpNumberIncrement()
    {
        jumpCount++;
        jumpCountText.text = jumpCount.ToString();
    }
    private void OnShootNumberIncrement()
    {
        shootCount++;
        shootCountText.text = shootCount.ToString();
    }
    private void Update()
    {
        timeCountText.text = Mathf.RoundToInt(Time.time).ToString();
    }
}
