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
    [SerializeField]
    private int MaxEntries = 4;


    private Ranking ranking;
    void Start()
    {
        ranking = FindObjectOfType<Ranking>();
    }
    public void BuildList()
    {
        if (ranking == null)
            ranking = FindObjectOfType<Ranking>();

        foreach (Transform child in list.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int i = 0; i < ranking.List.Count; i++)
        {
            if (i > MaxEntries)
                break;
            RankingEntry entry = Instantiate(entryPrefab, list.transform).GetComponent<RankingEntry>();
            entry.Initialize(ranking.List[i].Name, (i + 1).ToString(), ranking.List[i].Score.ToString());
        }
    }
}
