using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuScore : MonoBehaviour
{
    [SerializeField] private TMP_Text highScore;
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }

}
