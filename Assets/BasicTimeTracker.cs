using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicTimeTracker : MonoBehaviour
{
    Time_manager time_manager;

    // Start is called before the first frame update
    void Start()
    {
        time_manager = GameObject.FindObjectOfType<Time_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "Time: " + FormatTime(time_manager.GetTime()) + "\nDay: " + (time_manager.GetDay() + 1).ToString() + "\nSeason: " + time_manager.GetSeason().ToString();
    }


    string FormatTime(float seconds)
    {
        int secs = (int)seconds;
        int minutes = (int)(secs / 60);
        secs -= minutes * 60;
        string minuteExtra = "";

        if(minutes < 10)
        {
            minuteExtra = "0";
        }

        string secExtra = "";

        if (secs < 10)
            secExtra = "0";


        return minuteExtra + minutes.ToString() + ":" + secExtra + secs.ToString();
    }

}
