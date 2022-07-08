using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// </summary>
[Serializable]
public class ObjectPoolItem
{
    public string name;
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;

    public ObjectPoolItem(GameObject obj, int amt, bool exp = true)
    {
        objectToPool = obj;
        amountToPool = Mathf.Max(amt, 2);
        shouldExpand = exp;
    }
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<ObjectPoolItem> itemsToPool;
    public List<List<GameObject>> pooledObjectsList;
    public List<GameObject> pooledObjects;
    private List<int> positions;

    private void Awake()
    {
        SharedInstance = this;

        pooledObjectsList = new List<List<GameObject>>();
        pooledObjects = new List<GameObject>();
        positions = new List<int>();
        
        for (var i = 0; i < itemsToPool.Count; i++) ObjectPoolItemToPooledObject(i);
    }

    public GameObject GetPooledObject(int index)
    {
        var curSize = pooledObjectsList[index].Count;
        for (var i = positions[index] + 1; i < positions[index] + pooledObjectsList[index].Count; i++)
            if (!pooledObjectsList[index][i % curSize].activeInHierarchy)
            {
                positions[index] = i % curSize;
                return pooledObjectsList[index][i % curSize];
            }

        if (itemsToPool[index].shouldExpand)
        {
            var obj = Instantiate(itemsToPool[index].objectToPool);
            obj.SetActive(false);
            obj.transform.parent = transform;
            pooledObjectsList[index].Add(obj);
            return obj;
        }

        return null;
    }

    public List<GameObject> GetAllPooledObjects(int index)
    {
        return pooledObjectsList[index];
    }

    public int AddObject(GameObject GO, int amt = 3, bool exp = true)
    {
        var item = new ObjectPoolItem(GO, amt, exp);
        var currLen = itemsToPool.Count;
        itemsToPool.Add(item);
        ObjectPoolItemToPooledObject(currLen);
        return currLen;
    }

    private void ObjectPoolItemToPooledObject(int index)
    {
        var item = itemsToPool[index];

        pooledObjects = new List<GameObject>();
        for (var i = 0; i < item.amountToPool; i++)
        {
            var obj = Instantiate(item.objectToPool);
            obj.SetActive(false);
            obj.transform.parent = transform;
            pooledObjects.Add(obj);
        }

        pooledObjectsList.Add(pooledObjects);
        positions.Add(0);
    }
}