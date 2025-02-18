using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsUI : MonoBehaviour
{
    public TMP_Dropdown difficult;

    int currentDifficult;
    float ballSpeed;

    private void Start()
    {
        SetDifficult();
    }

    private void Update()
    {
        SetDifficult();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetDifficult()
    {
        switch (difficult.value)
        {
            case 0:
                GameManager.Instance.maxBallSpeed = 3.0f;
                GameManager.Instance.scoreMultiplier = 1.0f;
                break;
            case 1:
                GameManager.Instance.maxBallSpeed = 4.0f;
                GameManager.Instance.scoreMultiplier = 1.5f;
                break;
            case 2:
                GameManager.Instance.maxBallSpeed = 5.0f;
                GameManager.Instance.scoreMultiplier = 3.0f;
                break;
            default:
                GameManager.Instance.maxBallSpeed = 3.0f;
                GameManager.Instance.scoreMultiplier = 1.0f;
                break;
        }
    }
}
