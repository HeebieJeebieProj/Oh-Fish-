using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

	// Use this for initialization
	void Start () {

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {

            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {

                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);

            }

            poolDictionary.Add(pool.tag, objectPool);

        }
		
	}
	

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary[tag].Count > 0)
        {

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            InterfacePooledObject[] pooledObject = objectToSpawn.GetComponents<InterfacePooledObject>();

            if (pooledObject != null)
            {
                for (int i = 0; i < pooledObject.Length; i++)
                {
                    pooledObject[i].OnObjectSpawn();
                }
            }

            return objectToSpawn;

        }

        return null;

    }

    public void EnqueueToPool(string tag, GameObject objectToQueue)
    {

        objectToQueue.SetActive(false);
        poolDictionary[tag].Enqueue(objectToQueue);

    }

}
