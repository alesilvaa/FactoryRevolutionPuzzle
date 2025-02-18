using System.Collections;
using UnityEngine;

public class BoxParent : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;   // Referencia al pool

    private void Start()
    {
        StartCoroutine(ActivarCubos());
    }

    private IEnumerator ActivarCubos()
    {
        for (int i = 0; i < objectPool.PoolSize; i++)
        {
            GameObject box = objectPool.GetObject();
            if (box != null)
            {
                box.transform.position = transform.position;
                box.SetActive(true);
            }
            yield return new WaitForSeconds(0.6f); // Espera antes de activar la siguiente
        }
    }
}