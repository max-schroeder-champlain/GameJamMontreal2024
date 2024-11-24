using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBoxColliderScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<BoxScript>() != null)
        {
            Debug.Log("SetLeft");
            other.GetComponentInParent<BoxScript>().GoLeft = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<BoxScript>() != null)
        {
            Debug.Log("UnsetLeft");
            other.GetComponentInParent<BoxScript>().GoLeft = false;
        }
    }
}

