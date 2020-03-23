using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Ranking : MonoBehaviour
{
    public static string FILE_NAME = "ranking.json";

    private string RankingFilePath { get => Path.Combine(Application.persistentDataPath, FILE_NAME); }
    public int RankingCount { get => scoreList.Count; }

    [SerializeField]
    private List<int> scoreList;
    private void Awake()
    {
        LoadRanking();
    }
    private void Start()
    {
        
    }
    public void AddEntry(int newScore)
    {
        scoreList.Add(newScore);
        SaveRanking();
    }
    private void LoadRanking()
    {
        string json = File.ReadAllText(RankingFilePath);
        JsonUtility.FromJsonOverwrite(json, this);
    }
    private void SaveRanking()
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(RankingFilePath, json);
        Debug.Log(Application.persistentDataPath);
    }
}
