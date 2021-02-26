using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    private int highscore = 0;
    public Text scoreText;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetInt("Highscore");
        }
    }

    private void Start()
    {
        scoreText.text = "Highscore: " + highscore.ToString();
    }
}
   
