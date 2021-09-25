﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour
{
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
