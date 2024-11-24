using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text Score;
    public Text ScoreMultiplier;
    public Text Time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = ScoreScript.Instance.Score.ToString();
        ScoreMultiplier.text = (( Mathf.Round(Timer.Instance.ReturnScoreMultiplier()*100))/100f).ToString("F2")+("x");
        if (Timer.Instance.time.Seconds < 10)
        {
            Time.text = Timer.Instance.time.Minutes.ToString() + ":0" + Timer.Instance.time.Seconds.ToString();
        }
        else
        {
            Time.text = Timer.Instance.time.Minutes.ToString() + ":" + Timer.Instance.time.Seconds.ToString();
        }
        
    }
}
