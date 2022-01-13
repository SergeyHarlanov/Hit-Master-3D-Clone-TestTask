using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObj
{
    public GameObject _prefab;

    private Queue<GameObject> _pool = new Queue<GameObject>();

    public void InitialPool(GameObject prefab)
    {
        _prefab = prefab;
    }

    public GameObject CreatePool()
    {
        foreach (var item in _pool)
        {
            if (!item.activeSelf)
            {
                item.SetActive(true);
                return item;
            }
        }
        return CreateObject();
    }
    public GameObject CreateObject()
    {
        GameObject ob = Object.Instantiate(_prefab) as GameObject;
        _pool.Enqueue(ob);
        return ob;
    }
}