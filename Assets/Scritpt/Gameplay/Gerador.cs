using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject prefabInimigo;
    [SerializeField]
    private ScoreSystem scoreSystem;
    [SerializeField]
    private float tempo;
    [SerializeField]
    private float raio;
    [SerializeField]
    private float enemySpeed = 1;

    private void Start()
    {
        InvokeRepeating("Instanciar", 0, tempo);
    }

    private void Instanciar()
    {
        var inimigo = GameObject.Instantiate(this.prefabInimigo);
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
