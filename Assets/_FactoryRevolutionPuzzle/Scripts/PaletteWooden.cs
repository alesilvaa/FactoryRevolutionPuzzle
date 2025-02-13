using System.Collections.Generic;
using UnityEngine;

public class PaletteWooden : MonoBehaviour
{
    [SerializeField] private List<Transform> positionsToMove;
    private int currentIndex = 0; // Lleva el seguimiento de la posición actual

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            if (currentIndex < positionsToMove.Count)
            {
                other.GetComponent<MoverPorWaypoints>().enabled = false;
                // Mueve el cubo a la posición y rotación definidas en la lista
                other.transform.position = positionsToMove[currentIndex].position;
                other.transform.rotation = positionsToMove[currentIndex].rotation;
                
                // Incrementa el índice para la siguiente posición
                currentIndex++;
            }
            else
            {
                Debug.LogWarning("No hay más posiciones disponibles en la lista.");
            }
        }
    }
}