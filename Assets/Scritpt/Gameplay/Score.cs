using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public ScoreSystem ScoreSystem { get; set; }

    public void IncrementScore()
    {
        ScoreSystem.IncrementScore();
    }
}
