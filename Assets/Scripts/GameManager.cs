using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static string bestScoreText;
    public string playerName;
    public int bestScore = 0;
    List<PlayerScore> bestFiveScores = new List<PlayerScore>();

    [System.Serializable]
    struct PlayerScore
    {
        public string Name;
        public int Score;

        public PlayerScore(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    private void Start()
    {
        //bestScore = 0;
    }

    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (bestFiveScores == null)
        {
            bestFiveScores = new List<PlayerScore>();
        }

        LoadBestPointsAndName();
    }

    [System.Serializable]
    class SaveData
    {
        public List<PlayerScore> scores;
    }

    public void SaveBestPointsAndName()
    {
        SaveData data = new SaveData();
        data.scores = bestFiveScores;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";

        Debug.Log("Сохранение данных в: " + path);
        File.WriteAllText(path, json);    
    }

    public void LoadBestPointsAndName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log("Загрузка данных из: " + path); // Отладочный вывод

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestFiveScores = data.scores;
        }
        else
        {
            Debug.Log("Файл сохранения не найден. Создан новый список результатов.");
            bestFiveScores = new List<PlayerScore>();
        }
    }

    public void AddBestScore(string _name, int _score)
    {
        if (bestFiveScores == null)
        {
            bestFiveScores = new List<PlayerScore>();
        }

        bestFiveScores.Add(new PlayerScore(_name, _score));
        bestFiveScores.Sort((a, b) => b.Score.CompareTo(a.Score));
        if(bestFiveScores.Count > 5)
        {
            bestFiveScores.RemoveAt(5);
        }
    }

    public string ToStringScores()
    {
        string scoresText = "";
        if (bestFiveScores == null || bestFiveScores.Count == 0)
        {
            scoresText = "No records";
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                scoresText += i+1 + ". " + bestFiveScores[i].Name + ": " + bestFiveScores[i].Score + '\n';
            }
        }

        return scoresText;
    }
}
