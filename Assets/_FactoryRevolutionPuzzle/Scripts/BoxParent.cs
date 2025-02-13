using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxParent : MonoBehaviour
{
    [SerializeField] private GameObject prefabBox;         // Prefab del cubo a instanciar
    [SerializeField] private List<GameObject> boxes = new List<GameObject>(); // Lista para almacenar los cubos instanciados
    [SerializeField] private int cantidadCubos = 4;           // Cantidad de cubos a instanciar

    private void Start()
    {
        StartCoroutine(InstanciarCubos());
    }

    private IEnumerator InstanciarCubos()
    {
        for (int i = 0; i < cantidadCubos; i++)
        {
            GameObject nuevoCubo = Instantiate(prefabBox, transform.position, Quaternion.identity);
            boxes.Add(nuevoCubo);
            yield return new WaitForSeconds(.4f); // Espera 1 segundo antes de instanciar el siguiente cubo
        }
    }
}