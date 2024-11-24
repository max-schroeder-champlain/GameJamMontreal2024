using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    private float currentTime = 0;
    TimeSpan time = TimeSpan.Zero;
    private float PlayerScoreMultiplier;

    //ADJUST THIS TO CHANGE THE MAXIMUM SCORE MULTIPLIER
    private float PlayerScoreMultiplierMAX = 6;

    //ADJUST THESE TO ACCOUNT FOR PAR TIME (Remember: 1 Minute is 60 Seconds, so do the math to implement)
    private int ScoreMultiDepreciateStart = 5;
    private int ScoreMultiDepreciateEnd = 35;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        time = TimeSpan.FromSeconds(currentTime);

        if ( (int) currentTime <= ScoreMultiDepreciateStart)
        {
            PlayerScoreMultiplier = PlayerScoreMultiplierMAX;
        }
        else if ((int) currentTime > ScoreMultiDepreciateStart && (int) currentTime < ScoreMultiDepreciateEnd)
        {
        //It Calculates the Amount of Time Remaining before the 1x Multiplier by subtracting the Time that's passed since the Start of the Depreciation from the Total Time Gap of the Depreciation.
        //It then takes that number and divides it by the total time so that we convert it into a percentage.
         PlayerScoreMultiplier = ((float)(ScoreMultiDepreciateEnd - ScoreMultiDepreciateStart) - (currentTime - (float) ScoreMultiDepreciateStart)) / (float) (ScoreMultiDepreciateEnd-ScoreMultiDepreciateStart);
         //The Percentage is then applied to the Maximum Multiplier (the -1 is to account for the fact we end at 1 and not 0)
         //The +1 is likewise also to account for that fact
         PlayerScoreMultiplier = PlayerScoreMultiplier * (PlayerScoreMultiplierMAX - 1) +1;
        }
        else if ((int) currentTime >= ScoreMultiDepreciateEnd)
        {
            PlayerScoreMultiplier = 1;
        }


        //Debug.Log(currentTime);
       // Debug.Log(PlayerScoreMultiplier);


    }

    public float ReturnScoreMultiplier()
    {
        return PlayerScoreMultiplier;
    }
}
