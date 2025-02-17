using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento

    private void Start()
    {
        EventsManager.Instance.OnAllBoxesInTruck += MoveToExit;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnAllBoxesInTruck -= MoveToExit;
    }

    // Función para activar las partículas.
    public void ActivateParticles()
    {
        particles.Play();
    }

    // Función para iniciar el movimiento hacia X = -20.
    public void MoveToExit()
    {
        StartCoroutine(MoveToNeg20());
        ActivateParticles();
    }

    // Corrutina que mueve el objeto hasta que su posición en X sea -20.
    private IEnumerator MoveToNeg20()
    {
        Vector3 targetPosition = new Vector3(-20f, transform.position.y, transform.position.z);

        // Mientras la posición actual en X sea mayor que -20, seguimos moviendo el objeto.
        while (transform.position.x > -20f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
