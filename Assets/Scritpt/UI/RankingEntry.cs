using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingEntry : MonoBehaviour
{
    [SerializeField]
    private Text position;
    [SerializeField]
    private Text holder;
    [SerializeField]
    private Text score;

    private string Position { set => position.text = value; }
    private string Name { set => holder.text = value; }
    private string Score { set => score.text = value; }

    public void Initialize(string name, string position, string score)
    {
        Position = position;
        Name = name;
        Score = score;
    }
}
