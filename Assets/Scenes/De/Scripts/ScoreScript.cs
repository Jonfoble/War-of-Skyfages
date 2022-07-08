using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    Text score;
    public static int scoreValue = 0;
    public static int maxScore;
    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        maxScore = Mathf.Max(scoreValue);
        score.text = "Score: " + scoreValue;
        if (scoreValue > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", scoreValue);
        }
    }
}
