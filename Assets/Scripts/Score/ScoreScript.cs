using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        //StartCoroutine(ExampleCoroutine());
        //SceneManager.LoadScene("ResultsScreen");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(this.gameObject);
        }
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
