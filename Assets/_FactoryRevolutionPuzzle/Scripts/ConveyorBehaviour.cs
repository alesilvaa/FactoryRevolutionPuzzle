using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBehaviour : MonoBehaviour
{
    [SerializeField] private float correctConveyorRadius;
    private bool correctConveyor;

    private void Start()
    {
        EventsManager.Instance.OnIsCorrectRadius += IsCorrectRadius;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnIsCorrectRadius -= IsCorrectRadius;
    }

    private void IsCorrectRadius(float radius)
    {
        float tolerance = 0.01f;
        if (Mathf.Abs(radius - correctConveyorRadius) < tolerance)
        {
            correctConveyor = true;
        }
        else
        {
            correctConveyor = false;
        }
    }

}