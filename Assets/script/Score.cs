using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
public class Score : MonoBehaviour
{
    public float score = 0f; // Starting score
    public float highscore = 0f;
    public TextMeshProUGUI scoreText; // Reference to the UI text object that displays the score
    public TextMeshProUGUI highscoreText;

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", 0);
        highscoreText.text = "HIGHSCORE: "+ highscore.ToString(); 
    }
    // This function is called when the score object collides with the Ball1 object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball2"))
        {
            score =score +0.5f; // Increase score by 1
            UpdateScoreText(); // Update the score text in the UI
            
        }
    }

    // This function updates the score text in the UI
    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update the score text with the new score value
            
            if(highscore < score)
           PlayerPrefs.SetFloat("highscore", score); 
        }
    }
}