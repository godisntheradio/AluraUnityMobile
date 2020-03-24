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
        var posicaoAleatoria = new Vector3(Random.Range(-this.raio, this.raio), Random.Range(-this.raio, this.raio), 0);
        var posicaoInimigo = this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }
}
