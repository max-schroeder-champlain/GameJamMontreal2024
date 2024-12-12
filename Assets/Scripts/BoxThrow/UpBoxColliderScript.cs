using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPBoxColliderScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<BoxScript>() != null)
        {
            other.GetComponentInParent<BoxScript>().GoUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<BoxScript>() != null)
        {
            other.GetComponentInParent<BoxScript>().GoUp = false;
        }
    }
}

