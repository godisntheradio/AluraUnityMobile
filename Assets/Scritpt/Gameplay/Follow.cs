using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform alvo;

    private Rigidbody2D Physics;
    private void Awake()
    {
        Physics = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (alvo)
        {
            Vector3 dir = (alvo.position - transform.position).normalized;
            Physics.AddForce(dir * speed, ForceMode2D.Force);
        }
    }
    public void Init(Transform jogador, float enemySpeed)
    {
        speed = enemySpeed;
        alvo = jogador;
    }
}
