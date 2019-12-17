using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAnimation : MonoBehaviour {

    public bool uncontrollable;
    public float uctime = 3f;
    GameObject hit;

    public GameObject playerCharacter;
    PlayerInput playerinput;

    GameObject gamemanager;
    GameManagerScript GMS;

    public GameObject twigs;

    // Use this for initialization
    void Start () {
        playerinput = playerCharacter.GetComponent<PlayerInput>();

        gamemanager = GameObject.FindGameObjectWithTag("GameController");
        GMS = gamemanager.GetComponent<GameManagerScript>();

        hit = GameObject.FindGameObjectWithTag("Hit");
        hit.SetActive(false);
        uctime = 1f;

        twigs.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (playerinput.uncontrollable)
        {
            uctime -= Time.deltaTime;
            hit.SetActive(true);
        }

        if (uctime < 0)
        {
            playerinput.uncontrollable = false;
            hit.SetActive(false);
            uctime = 1f;
        }

        if (GMS.hasTwig)
        {
            twigs.SetActive(true);
        }
        else
        {
            twigs.SetActive(false);
        }
       
	}
}
