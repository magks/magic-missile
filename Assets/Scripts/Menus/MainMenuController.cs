﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start() { }

    public void playGame() {
        SceneManager.LoadScene("Level1"); //TODO: change to more sensible scene name for game scene
    }

    public void options() {

    }

    public void exitGame() {
        print("quit");
        Application.Quit();
    }
}
