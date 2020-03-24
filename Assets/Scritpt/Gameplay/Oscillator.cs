using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField]
    private float amplitude;
    [SerializeField]
    private float speed;


    private Vector3 initialPos;
    private Rigidbody2D Rigidbody;
    private float angle = 0;
    void Start()
    {
        initialPos = transform.position;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        angle += speed * Time.fixedDeltaTime;
        float variation = Mathf.Sin(angle);
        Rigidbody.MovePosition(initialPos + (amplitude * variation * Vector3.up));
    }
}
