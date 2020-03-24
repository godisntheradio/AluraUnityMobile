using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    public bool OverwriteOld;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        foreach (var item in GameObject.FindGameObjectsWithTag(tag))
        {
            if (item != gameObject)
            { 
                if(OverwriteOld)
                {
                    Destroy(item);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
