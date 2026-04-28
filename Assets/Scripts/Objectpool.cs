using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpool : MonoBehaviour
{
   [System.Serializable]
   public class Pool
    {
        public string name;
        public GameObject prefab;
        public int size;
    }

    public static Objectpool Instance;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionay;

    private void Awake()
    {
        Instance = this;

        poolDictionay = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionay.Add(pool.name, objectPool);
        }
    }

    public GameObject SpawnFromPool(string name, Vector2 position, Quaternion rotation)
    {
        if (!poolDictionay.ContainsKey(name))
        {
            Debug.LogWarning("Pool with name" + name + "doesn't excist");
            return null;
        }
        

        GameObject objectToSpawn = poolDictionay[name].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionay[name].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
