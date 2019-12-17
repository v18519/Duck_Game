using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript instance = null;
    public GameObject playerCharacter;
    public Vector3 playerPosition;
    public bool hasTwig = false;
    public float startTime;
    public float time;
    public bool timer = true;

    public int stickCount;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);

        time = Time.time;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {
        if(playerCharacter != null)playerPosition = playerCharacter.transform.position;
        if(timer)time = Time.time - startTime;
    }

    public void PickUpSticks()
    {
        hasTwig = true;
    }

    public void AddedStickToNest()
    {
        hasTwig = false;
    }

    public bool CanBuild()
    {
        return hasTwig;
    }

    public void TimeToFile()
    {
        string path = "Assets/Time.txt";
        System.IO.FileInfo file = new System.IO.FileInfo(path);
        file.Directory.Create();
        StreamWriter writer = new StreamWriter(path, true);
        time = Mathf.CeilToInt(time);
        writer.WriteLine(time.ToString());
        writer.Close();
    }
}
