using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    int hour;
    int minute;
    int second;
    int millisecond;


    float timeSpend = 0.0f;

    Text TimeText;

    // Use this for initialization
    void Start()
    {
        TimeText = GetComponent<Text>();        
    }

    // Update is called once per frame
    void Update()
    {
        timeSpend += Time.deltaTime;
        hour = (int)timeSpend / 3600;
        minute = ((int)timeSpend - hour * 3600) / 60;
        second = (int)timeSpend - hour * 3600 - minute * 60;
        millisecond = (int)((timeSpend - (int)timeSpend) * 1000);
        TimeText.text = string.Format("Time: {1:D2}:{2:D2}", hour, minute, second, millisecond);
    }
}