﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSceneButtonController : MonoBehaviour {


    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnReturnButtonClick()
    {
       SceneManager.LoadScene("StartScene");

    }
}
