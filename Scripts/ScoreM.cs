using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreM : MonoBehaviour {

    public List<Score> scoreList = new List<Score>();

    // Use this for initialization
    void Awake() {
        LoadScore();
        sortScore();
	}

    void Start()
    {
        showScore();
    }
	
	// Update is called once per frame
	void Update () {
        showScore();
    }

    public void showScore()
    {
        GameObject.Find("1stn").GetComponent<Text>().text = scoreList[0].name;
        GameObject.Find("1stt").GetComponent<Text>().text = scoreList[0].score.ToString();
        GameObject.Find("2ndn").GetComponent<Text>().text = scoreList[1].name;
        GameObject.Find("2ndt").GetComponent<Text>().text = scoreList[1].score.ToString();
        GameObject.Find("3rdn").GetComponent<Text>().text = scoreList[2].name;
        GameObject.Find("3rdt").GetComponent<Text>().text = scoreList[2].score.ToString();
    }

    public void LoadScore()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/RankingList.txt");
        string nextLine;
        while ((nextLine = sr.ReadLine()) != null)
        {
            scoreList.Add(JsonUtility.FromJson<Score>(nextLine));
        }
        sr.Close();
    }


    public void addScore(string name, int score, List<Score> LS)
    {
        LS.Add(new Score(name, score));
    }

    public void sortScore()
    {
        scoreList.Sort();
        scoreList.Reverse();
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/RankingList.txt");
        if (scoreList.Count > 3) for (int i = 3; i <= scoreList.Count; i++) scoreList.RemoveAt(i);
        for (int i = 0; i < scoreList.Count; i++)
        {
            sw.WriteLine(JsonUtility.ToJson(scoreList[i]));
            Debug.Log(scoreList[i].ToString());
        }
        sw.Close();
    }
}
