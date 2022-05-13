// By Wojciech "HyeroDrimm" Wroñski

using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 0.05f;

    [Header("Fields")]
    [SerializeField] private Transform platform;
    [SerializeField] private List<Transform> movePoints;


    private int currentPlatform = 0;
    private float currentPosition = 0f;

    private void Awake()
    {
        if (movePoints.Count < 2)
            Debug.LogError("Platform has less than 2 move points!");

        platform.position = movePoints[0].position;
    }

    private void FixedUpdate()
    {
        MovePlatform();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = platform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

    private void MovePlatform()
    {
        currentPosition += speed * Time.deltaTime;
        platform.position = Vector3.Lerp(movePoints[currentPlatform].position, movePoints[currentPlatform + 1].position, currentPosition);


        if (Vector3.Distance(platform.position, movePoints[currentPlatform + 1].position) <= 0.01f)
        {
            currentPosition = 0f;
            if (currentPlatform == movePoints.Count - 2)
            {
                currentPlatform = 0;
                movePoints.Reverse();
            }
            else
            {
                currentPlatform++;
            }
        }

    }
}
