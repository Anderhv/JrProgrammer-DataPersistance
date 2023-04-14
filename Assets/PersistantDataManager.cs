using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistantDataManager : MonoBehaviour
{
    public static PersistantDataManager Instance;
    public string PlayerName;

    [System.Serializable]
    public class HighScoreData
    {
        public int Score;
        public string Name;
    }

    public HighScoreData HighScore;

    private string _pathToHighScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _pathToHighScore = Application.persistentDataPath + "/highscore.json";
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        LoadHighScore();
    }



    public void SaveHighScore(int score)
    {
        HighScoreData data = new HighScoreData()
        {
            Name = PlayerName,
            Score = score
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(_pathToHighScore, json);
    }

    public void LoadHighScore()
    {
        if (!File.Exists(_pathToHighScore))
        {
            return;
        }
        string json = File.ReadAllText(_pathToHighScore);
        HighScoreData highScoreData = JsonUtility.FromJson<HighScoreData>(json);
        HighScore.Name = highScoreData.Name;
        HighScore.Score = highScoreData.Score;
    }
}
