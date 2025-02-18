using System;
using UnityEngine;


public class ConveyorBehaviour : MonoBehaviour
{
    [SerializeField] private ConveyorController conveyorController;
    [SerializeField] private float correctConveyorRadius;
    [SerializeField] private float incorrectConveyorRadius;
    [SerializeField] private RotateBox rotateBox;
    private bool correctConveyor;
    [SerializeField] private DirectionSelected correctDirection;
    [SerializeField] private DirectionSelected incorrectDirection;
    [SerializeField] private ScrollBaseMapY scrollBaseMapY;
    [SerializeField] private float scrollSpeedCorrect = -0.5f;
    [SerializeField] private float scrollSpeedIncorrect = 0.5f;
    

    // Propiedad para acceder al valor de correctConveyor desde otros scripts
    public bool IsCorrectConveyor 
    { 
        get { return correctConveyor; } 
    }

    private void Start()
    {
        float yRotation = transform.eulerAngles.y;
        IsCorrectRadius(yRotation);
    }

    

    public void IsCorrectRadius(float radius)
    {
        float tolerance = 0.01f;
        if (Mathf.Abs(Mathf.DeltaAngle(radius, correctConveyorRadius)) < tolerance)
        {
            correctConveyor = true;
            conveyorController.AddCorrectConveyor(this);
            scrollBaseMapY.ScrollSpeed = scrollSpeedCorrect;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            rotateBox.GetComponent<BoxCollider>().enabled = true;
            rotateBox.CheckDirection(correctDirection);
        }
        else if (Mathf.Abs(Mathf.DeltaAngle(radius, incorrectConveyorRadius)) < tolerance)
        {
            correctConveyor = false;
            conveyorController.RemoveCorrectConveyor(this);
            scrollBaseMapY.ScrollSpeed = scrollSpeedIncorrect;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            rotateBox.GetComponent<BoxCollider>().enabled = true;
            rotateBox.CheckDirection(incorrectDirection);
        }
        else
        {
            correctConveyor = false;
            scrollBaseMapY.ScrollSpeed = 0;
            conveyorController.RemoveCorrectConveyor(this);
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            rotateBox.GetComponent<BoxCollider>().enabled = false;
        }
    }

    
    
    
}