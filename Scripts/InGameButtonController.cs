using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameButtonController : MonoBehaviour {

    GameObject InGameOptionMenu;
    Slider VolumeSlider;
   // bool x = false;
    public GameObject Tutorial;

    GameObject gamemanager;
    GameManagerScript gamemanagerscript;

    void Awake()
    {
        VolumeSlider = GameObject.FindGameObjectWithTag("VolumeSlider").GetComponent<Slider>();
        InGameOptionMenu = GameObject.FindGameObjectWithTag("InGameOptionMenu");
        InGameOptionMenu.SetActive(false);
        Tutorial = GameObject.FindGameObjectWithTag("Tutorial");

        gamemanager = GameObject.FindGameObjectWithTag("GameController");
        gamemanagerscript = gamemanager.GetComponent<GameManagerScript>();
    }
    // Use this for initialization
    void Start () {
        Time.timeScale = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   

    public void OnPause()
    {
        Time.timeScale = 0;
        InGameOptionMenu.SetActive(true);
       // x = true;

    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        InGameOptionMenu.SetActive(false);
       // x = false;
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
        gamemanagerscript.startTime = Time.time;
    }

    public void OnReturnMenu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }

    public void CloseTutorial()
    {
        Time.timeScale = 1f;
        Tutorial.SetActive(false);
    }
}
