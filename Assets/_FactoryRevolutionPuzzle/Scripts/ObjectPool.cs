using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabBox;  // Prefab que se va a reutilizar
    [SerializeField] private int poolSize = 100;       // Tamaño del pool

    public int PoolSize => poolSize;
    private List<GameObject> pool;

    private void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefabBox, transform.position, Quaternion.identity);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    // Método para obtener un objeto inactivo del pool
    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null; // Opcional: puedes instanciar uno nuevo si lo deseas
    }
}