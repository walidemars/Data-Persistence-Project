using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scores;


    private void Awake()
    {
        scores.text = GameManager.Instance.ToStringScores();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
