using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 20;

    private List<GameObject> pool = new List<GameObject>();

    private void Start()
    {
        // Fill the pool with inactive bullets
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        // Find the first inactive bullet
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        GameObject newObj = Instantiate(bulletPrefab);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}
