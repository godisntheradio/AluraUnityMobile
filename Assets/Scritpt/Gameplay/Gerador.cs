using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private ScoreSystem scoreSystem;
    [SerializeField]
    private float tempo;
    [SerializeField]
    private float raio;
    [SerializeField]
    private float enemySpeed = 1;
    [SerializeField]
    private ObjectPool Pool;
    [SerializeField]
    private Rect area;

    private void Start()
    {
        InvokeRepeating("Instanciar", 0, tempo);
    }

    private void Instanciar()
    {
        var inimigo = Pool.GetObjectFromPool();
        if (inimigo == null)
            return;
        inimigo.SetActive(true);
        this.DefinirPosicaoInimigo(inimigo);
        inimigo.GetComponent<Follow>().Init(player.transform, enemySpeed);
        inimigo.GetComponent<Score>().ScoreSystem = scoreSystem;
        
    }

    private void DefinirPosicaoInimigo(GameObject inimigo)
    {
        var posicaoAleatoria = new Vector3(Random.Range(transform.position.x, transform.position.x + area.width), Random.Range(transform.position.y, transform.position.y + area.height), 0);
        inimigo.transform.position = posicaoAleatoria;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 150, 100);
        Gizmos.DrawWireCube(transform.position + (Vector3)area.size / 2, (Vector3)area.size);
    }
}
