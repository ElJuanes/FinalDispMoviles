using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public GameObject speedPrefab;
    public GameObject growPrefab;
    public int poolSize = 15;
    private List<GameObject> fallingObjectsPool;
    private List<GameObject> speedObjectsPool;
    private List<GameObject> growObjectsPool;

    private void Start()
    {
        fallingObjectsPool = new List<GameObject>();
        speedObjectsPool = new List<GameObject>();
        growObjectsPool = new List<GameObject>();

        // Inicializar los pools con los objetos
        InitializePool(fallingObjectPrefab, fallingObjectsPool);
        InitializePool(speedPrefab, speedObjectsPool);
        InitializePool(growPrefab, growObjectsPool);
    }

    private void InitializePool(GameObject prefab, List<GameObject> pool)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetFallingObject()
    {
        return GetPooledObject(fallingObjectsPool);
    }

    public GameObject GetSpeedObject()
    {
        return GetPooledObject(speedObjectsPool);
    }

    public GameObject GetGrowObject()
    {
        return GetPooledObject(growObjectsPool);
    }

    // Cambiar la firma de este método para que acepte un pool
    public GameObject GetPooledObject(List<GameObject> pool)
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // Si no hay objetos inactivos, crear uno nuevo
        GameObject newObj = Instantiate(fallingObjectPrefab); // Usa prefab genérico o uno específico si es necesario
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}
