using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    public ObjectPool Pool { get; set; }

    public void ReturnToPool() => Pool.ReturnObject(gameObject);
}
