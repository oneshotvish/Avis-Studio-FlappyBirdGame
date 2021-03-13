using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    private float highscore = 0;
    public Text scoreText;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetFloat("Highscore");
        }
    }

    private void Start()
    {
        scoreText.text = "Highscore: " + System.Math.Round(highscore, 1).ToString();
    }
}
   
