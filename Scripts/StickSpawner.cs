using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSpawner : MonoBehaviour {

    GameObject gameManager;
    GameManagerScript gameManagerScript;

    public GameObject twiggy;
    float lastSpawn = 0;
    Renderer renderer;

    int maxStickCount = 10;

    float maxActiveDistance = 10;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        renderer = GetComponent<Renderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Enabled() && Random.Range(0, 100) > 70 && lastSpawn <= 0 && gameManagerScript.stickCount < maxStickCount)
        {
            Instantiate(twiggy, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z), Random.rotation);
            lastSpawn = 60;
            gameManagerScript.stickCount++;
        }
        lastSpawn -= Time.deltaTime;
	}

    float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, gameManagerScript.playerPosition);
    }

    bool Enabled()
    {
        if (renderer.isVisible)
        {
            return false;
        }
        if (!renderer.isVisible && DistanceToPlayer() < maxActiveDistance)
        {
            return true;
        }
        else return false;

    }

}
