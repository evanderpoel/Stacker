using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text highScore;
    [SerializeField] private TMP_Text currentScore;
    [SerializeField] private GameObject inGameUI;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        int current = Int32.Parse(currentScore.text);
        int gameHighScore = Int32.Parse(highScore.text);

        if (current > gameHighScore)
        {
            highScore.text = current.ToString();
            PlayerPrefs.SetInt("highScore", current);
        }

        score.text = current.ToString();
        inGameUI.SetActive(false);
    }
    
}
