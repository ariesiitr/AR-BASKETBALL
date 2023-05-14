using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI PointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        PointsText.text = score.ToString() + " Points";
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene(0);
    }
}
