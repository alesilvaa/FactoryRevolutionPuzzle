using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionSelected
{
    forward,
    back,
    left,
    right
}

public class RotateBox : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private DirectionSelected directionSelected;

    public Vector3 Direction
    {
        get => direction;
        set => direction = value;
    }

    private void Start()
    {
        //CheckDirection(directionSelected);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            // Aquí se utiliza el vector asignado en Start()
            other.GetComponent<MoverPorWaypoints>().direction = direction;
        }
    }


    public void CheckDirection(DirectionSelected dirSelected)
    {
        switch (dirSelected)
        {
            case DirectionSelected.forward:
                direction = Vector3.forward;
                break;
            case DirectionSelected.back:
                direction = Vector3.back;
                break;
            case DirectionSelected.left:
                direction = Vector3.left;
                break;
            case DirectionSelected.right:
                direction = Vector3.right;
                break;
            default:
                direction = Vector3.zero;
                break;
        }
    }
}