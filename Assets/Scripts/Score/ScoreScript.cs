using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class ScoreScript : MonoBehaviour
{
   public static ScoreScript Instance;
       //public UnityEvent CatDelivered;

    //private int ScoreValue;

    public int Score;

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
    private void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        Score = Score + (int) (100f *  Timer.Instance.ReturnScoreMultiplier());
        //Debug.Log(Score);
        StartCoroutine(ExampleCoroutine());
    }

    public int ReturnScore()
    {
        return Score;
    }
}
