using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBoxColliderScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box")
        {
            Debug.Log("SetLeft");
            other.GetComponent<BoxScript>().GoLeft = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Box")
        {
            Debug.Log("UnsetLeft");
            other.GetComponent<BoxScript>().GoLeft = false;
        }
    }
}

