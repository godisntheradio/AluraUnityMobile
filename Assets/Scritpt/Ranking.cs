using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.ObjectModel;
using UnityEngine.Events;
using System;

public class Ranking : MonoBehaviour
{
    public static string FILE_NAME = "ranking.json";
    private string RankingFilePath { get => Path.Combine(Application.persistentDataPath, FILE_NAME); }

    [SerializeField]
    private List<RankingEntryData> scoreList;
    [SerializeField]
    private string currentID;

    private RankingWindow Window;

    public ReadOnlyCollection<RankingEntryData> List { get => scoreList.AsReadOnly(); }

    private void Awake()
    {
        LoadRanking();
    }
    private void Start()
    {
        Window = FindObjectOfType<RankingWindow>();

    }
    public void AddEntry(string name, int newScore)
    {
        currentID = Guid.NewGuid().ToString();
        scoreList.Add(new RankingEntryData(name, newScore, currentID));
        scoreList.Sort();
        Window.BuildList();
        SaveRanking();
    }
    public void ChangeEntryName(string newName)
    {
        foreach (var item in scoreList)
        {
            if (item.ID == currentID)
            {
                item.Name = newName;
            }
        }
        SaveRanking();
        Window.BuildList();
    }
    private void LoadRanking()
    {
        if(File.Exists(RankingFilePath))
        {
            string json = File.ReadAllText(RankingFilePath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            scoreList = new List<RankingEntryData>();
            currentID = "";
        }
    }
    private void SaveRanking()
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(RankingFilePath, json);
        Debug.Log(Application.persistentDataPath);
    }
}
[System.Serializable]
public class RankingEntryData : System.IComparable
{
    public string ID;
    public string Name;
    public int Score;

    public RankingEntryData(string name, int score, string id)
    {
        ID = id;
        Name = name;
        Score = score;
    }

    public int CompareTo(object obj)
    {
        RankingEntryData other = obj as RankingEntryData;
        return other.Score.CompareTo(Score);
    }
}