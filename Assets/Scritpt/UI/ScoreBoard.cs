using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private DynamicText text;
    [SerializeField]
    private Ranking ranking;

    private ScoreSystem scoreSystem;
    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        int currentScore = -1;
        if (scoreSystem != null)
        {
            currentScore = scoreSystem.Score;
        }
        ranking.AddEntry("name", currentScore);
        text.UpdateText(currentScore);
    }
}
