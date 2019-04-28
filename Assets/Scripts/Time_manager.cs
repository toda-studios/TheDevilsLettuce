using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Time_manager : MonoBehaviour
{
    public enum Season
    {
        SPRING, SUMMER, FALL, WINTER
    }
    const int NUMBER_OF_SEASONS = 4;

    const int minutesPerDay = 5;
    const int daysPerSeason = 2;

    int day = 0;
    Season currentSeason = Season.SPRING;

    public int GetDay()
    {
        return day;
    }
    public Season GetSeason()
    {
        return currentSeason;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeWhenDayBegan = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForNextDay();
    }

    float timeWhenDayBegan;

    public float currentLengthOfDay()
    {
        return Time.time - timeWhenDayBegan;
    }

    void CheckForNextDay()
    {
        if(currentLengthOfDay()/60 > minutesPerDay)
        {
            day++;
            CheckForNextSeason();
            timeWhenDayBegan = Time.time;
            Debug.Log("Welcome to day #" + day.ToString());
        }
    }

    void CheckForNextSeason()
    {
        if(day > daysPerSeason)
        {
            day = 0;
            if((int)currentSeason + 1 > NUMBER_OF_SEASONS)
            {
                currentSeason = Season.FALL;
            }
            else
            {
                currentSeason++;
            }
            Debug.Log("Welcome to: " + currentSeason.ToString());
        }
    }

    public float PercentOfDay()
    {
        return currentLengthOfDay() / 60 / minutesPerDay;
    }




}
