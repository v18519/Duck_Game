using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyScript : MonoBehaviour {

    GameObject gameManager;
    GameManagerScript gameManagerScript;
    public Sprite twiggy;
    SpriteRenderer twiggyRenderer;
    double timeRemaining = 8;
    // Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

        twiggyRenderer = GetComponent<SpriteRenderer>();
        twiggyRenderer.sprite = twiggy;

	}

    void Update()
    {
        if (!twiggyRenderer.isVisible && timeRemaining < 0)
        {
            gameManagerScript.stickCount--;
            Destroy(gameObject);
        }
        timeRemaining -= Time.deltaTime;
    }

    public void DoTwiggyThings()
    {
        if (gameManagerScript.hasTwig != true)
        {
            gameManagerScript.PickUpSticks();
            gameManagerScript.stickCount--;
            Destroy(gameObject);
        }
        Debug.Log("Did TwiggyThings");
    }
}
