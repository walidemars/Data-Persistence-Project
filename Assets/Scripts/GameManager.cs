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
    public string bestName;
    public int bestScore = 0;


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

        LoadBestPointsAndName();
    }

    public string NewRecord()
    {
        if (bestName.Length == 0)
        {
            //Debug.Log("Имя не введено");
            return "Best Score: " + "Name" + ": " + bestScore;
        }
        else
        {
            return "Best Score: " + bestName + ": " + bestScore;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int saveScore;
        public string saveName;
    }

    public void SaveBestPointsAndName()
    {
        SaveData data = new SaveData();
        data.saveName = bestName;
        data.saveScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPointsAndName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestName = data.saveName;
            bestScore = data.saveScore;
        }
    }

    public void BestName(int cuurentPoints)
    {
        if (cuurentPoints > bestScore)
        {
            bestName = playerName;
        }
    }
}
