using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject PoolObject;
    [SerializeField]
    private int PoolSize;

    Stack<GameObject> Pool;
    private void Start()
    {
        Pool = new Stack<GameObject>();
        InstantiatePool();
    }
    private void InstantiatePool()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject gameObj = Instantiate(PoolObject, transform);
            Pool.Push(gameObj);
            Poolable poolable = gameObj.GetComponent<Poolable>();
            if (poolable == null)
                Debug.LogError("This object does not contain the 'Poolable' component.");
            gameObj.GetComponent<Poolable>().Pool = this;
            gameObj.SetActive(false);
            
        }
    }
    public GameObject GetObjectFromPool()
    {
        if (Pool.Count > 0)
            return Pool.Pop();
        else
            return null;
    }
    public void ReturnObject(GameObject gameObj)
    {
        gameObj.SetActive(false);
        Pool.Push(gameObj);
    }
}
