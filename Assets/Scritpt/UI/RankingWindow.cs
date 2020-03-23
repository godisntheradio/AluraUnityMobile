using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject entryPrefab;
    [SerializeField]
    private GameObject list;

    private Ranking ranking;
    void Start()
    {
        ranking = FindObjectOfType<Ranking>();
        for(int i = 0; i < ranking.RankingCount; i++)
        {
            if (i > 4)
                break;
            RankingEntry entry = Instantiate(entryPrefab, list.transform).GetComponent<RankingEntry>();
            //entry.Initialize();


        }
    }
}
