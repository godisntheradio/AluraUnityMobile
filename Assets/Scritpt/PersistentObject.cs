using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        foreach (var item in GameObject.FindGameObjectsWithTag(tag))
        {
            if (item != gameObject)
                Destroy(item);
        }
    }
}
