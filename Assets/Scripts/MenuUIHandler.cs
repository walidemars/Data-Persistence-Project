using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI bestScoreText;

    public void StartNew()
    {
        GameManager.Instance.playerName = nameText.text;
        SceneManager.LoadScene(1);
    }

    public void GoToHighScores()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        GameManager.Instance.SaveBestPointsAndName();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
