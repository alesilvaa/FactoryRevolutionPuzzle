using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPorWaypoints : MonoBehaviour
{
    // Velocidad de movimiento en unidades por segundo.
    public float speed = 5.0f;
    public Vector3 direction= Vector3.back;

    void Update()
    {
        // Mueve el objeto en el eje Z positivo.
        // Multiplicamos por Time.deltaTime para que el movimiento sea independiente de la tasa de frames.
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}