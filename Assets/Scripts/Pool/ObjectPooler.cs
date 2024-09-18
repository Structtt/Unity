using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int poolSize = 10;

    private List<GameObject> pool;
    //容器
    private GameObject poolContainer;

    private void Awake()
    {
        //创建对象池
        pool = new List<GameObject>();
        poolContainer = new GameObject($"Pool - {prefab.name}");
        CreatePooler();
    }

    private void CreatePooler()
    {
        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(CreateObject());
        }
    }

    //创建对象
    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.SetParent(poolContainer.transform);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetInstanceFromPool()
    {
        for(int i = 0;i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return CreateObject();
    }

    public static void ReturnPool(GameObject instance)
    {
        instance.SetActive(false);
    }
}
