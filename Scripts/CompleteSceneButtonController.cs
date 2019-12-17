using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteSceneButtonController : MonoBehaviour {

    GameObject gamemanager;
    GameManagerScript gms;
    int time;

    public InputField inputname;
    public string name;

    public Text showtime;

    public GameObject score;
    ScoreM scorem;
	// Use this for initialization
    void Awake()
    {
    }

	void Start () {
        gamemanager = GameObject.FindGameObjectWithTag("GameController");
        gms = gamemanager.GetComponent<GameManagerScript>();
        time = Mathf.CeilToInt(gms.time);
        showtime.text = "" + time.ToString();

        scorem = score.GetComponent<ScoreM>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnExitGameButtonClick()
    {
        name = inputname.text.ToString();
        Debug.Log(name);
        scorem.addScore(name, time, scorem.scoreList);
        scorem.sortScore();
        SceneManager.LoadScene(0);
    }
    
}
