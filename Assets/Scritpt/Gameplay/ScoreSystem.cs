using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private ScoreEvent onScore;
    public int Score { get; private set; }

    public void IncrementScore()
    {
        Score++;
        onScore.Invoke(Score);
    }
}
[System.Serializable]
public class ScoreEvent : UnityEvent<int>
{

}
