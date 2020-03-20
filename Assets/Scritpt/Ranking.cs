using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Ranking : MonoBehaviour
{
    public static string FILE_NAME = "ranking.json";
    [SerializeField]
    private List<int> scoreList;
    private void Start()
    {
        scoreList = new List<int>();
        LoadRanking();
    }
    public void AddEntry(int newScore)
    {
        scoreList.Add(newScore);
        SaveRanking();
    }
    private void LoadRanking()
    {

    }
    private void SaveRanking()
    {
        string json = JsonUtility.ToJson(this);
        string path = Path.Combine(Application.persistentDataPath, FILE_NAME);
        File.WriteAllText(path, json);
        Debug.Log(Application.persistentDataPath);
    }
}
