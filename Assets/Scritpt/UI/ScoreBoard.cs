using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private DynamicText scoreText;
    [SerializeField]
    private DynamicText nameText;
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
        ranking.AddEntry(GetCurrentName(), currentScore);
        scoreText.UpdateText(currentScore);
        nameText.UpdateText(GetCurrentName());
    }
    private string GetCurrentName()
    {
        if (PlayerPrefs.HasKey(Ranking.CurrentName))
        {
            return PlayerPrefs.GetString(Ranking.CurrentName);
        }
        return "Nome";
    }
}
