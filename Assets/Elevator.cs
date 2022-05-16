using System;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 0.05f;


    private Transform currentLevel;

    private void FixedUpdate()
    {
        if (currentLevel != null)
        {
            MovePlatformToLevel(currentLevel);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

    public void SetGoingLevel(Transform level)
    {
        currentLevel = level;
        OnPlatformDeparted();
    }

    private void MovePlatformToLevel(Transform level)
    {
        if (Vector3.Distance(level.position, transform.position) <= 0.01f)
        {
            OnPlatformArrived(level);
        }
        else
        {
            var direction = level.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed;
        }
    }

    private void OnPlatformArrived(Transform levelNumber)
    {
        print(levelNumber);
        currentLevel = null;
    }

    private void OnPlatformDeparted()
    {
        print("ElevatorDeparted");
    }
}
