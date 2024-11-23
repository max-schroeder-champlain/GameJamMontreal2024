using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class ScoreScript : MonoBehaviour
{
   public static ScoreScript Instance;
   public UnityEvent CatDelivered;

    private int ScoreValue;

    public int Score; 
}
