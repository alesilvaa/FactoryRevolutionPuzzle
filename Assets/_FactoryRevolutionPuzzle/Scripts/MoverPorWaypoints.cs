using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPorWaypoints : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>(); // Lista de waypoints
    public float velocidad = 2f;
    private int indiceActual = 0;
    private bool pausado = false; // Variable para controlar la pausa

    void Start()
    {
        // Buscamos el objeto que contiene las posiciones
        GameObject positionsContainer = GameObject.Find("PositonsLvl1");
        if (positionsContainer != null)
        {
            // Iteramos por cada hijo del objeto y lo agregamos a la lista de waypoints
            foreach (Transform child in positionsContainer.transform)
            {
                waypoints.Add(child);
            }
        }
        else
        {
            Debug.LogError("No se encontró el objeto 'PositonsLvl1' en la escena.");
        }
    }

    void Update()
    {
        // Comprobar si se presionan las teclas A o S para pausar/reanudar
        if (Input.GetKeyDown(KeyCode.A))
        {
            pausado = true;  // Pausa el movimiento
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            pausado = false; // Reanuda el movimiento
        }

        // Si está pausado, no se ejecuta el resto del Update
        if (pausado) return;

        if (waypoints.Count == 0) return;
        
        // Posición destino (waypoint actual)
        Vector3 destino = waypoints[indiceActual].position;
        
        // Mover hacia el destino
        transform.position = Vector3.MoveTowards(
            transform.position,
            destino,
            Mathf.Abs(velocidad) * Time.deltaTime
        );
        
        // Verificar si llegamos al waypoint
        if (Vector3.Distance(transform.position, destino) < 0.01f)
        {
            // Si la velocidad es positiva, avanzamos
            if (velocidad > 0)
            {
                // Solo avanzamos si aún no es el último waypoint
                if (indiceActual < waypoints.Count - 1)
                    indiceActual++;
                // Si es el último, se detiene
            }
            // Si la velocidad es negativa, retrocedemos
            else if (velocidad < 0)
            {
                // Solo retrocedemos si aún no es el primer waypoint
                if (indiceActual > 0)
                    indiceActual--;
                // Si es el primero, se detiene
            }
        }
    }
}
