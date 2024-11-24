using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ResultsScreenUI : MonoBehaviour
{
    public TMP_Text Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = ScoreScript.Instance.Score.ToString();
    }
}
