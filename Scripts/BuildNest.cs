using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildNest : MonoBehaviour {
    public List<Sprite> nestStageSprites = new List<Sprite>();
    private int nestStage = 0;
    public float spriteScaleFactor;

    GameObject gameManager;
    GameManagerScript gameManagerScript;

    PolygonCollider2D nestCollider;

    SpriteRenderer spriteRenderer;

    private static string transitionToScene = "EndScene";

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = nestStageSprites[nestStage];
        spriteRenderer.transform.localScale *= spriteScaleFactor;
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

        nestCollider = gameObject.AddComponent<PolygonCollider2D>();
        nestCollider.isTrigger = true;

    }

    public void AdvanceNestStage()
    {
        nestStage++;
        spriteRenderer.sprite = nestStageSprites[nestStage];
        gameManagerScript.AddedStickToNest();
        Debug.Log("Stage" + nestStage + " of " + (nestStageSprites.Count - 1));
        if (nestStage == nestStageSprites.Count - 1)
        {
            gameManagerScript.timer = false;
            gameManagerScript.TimeToFile();

            SceneManager.LoadScene(transitionToScene);
        }
    }

}
