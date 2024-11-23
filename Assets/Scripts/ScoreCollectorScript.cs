using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class ScoreCollectorScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boxes")
        {
            ScoreScript.Instance.Score += 5; 
            //make box child of the plane here!! 
        }
    }
}
