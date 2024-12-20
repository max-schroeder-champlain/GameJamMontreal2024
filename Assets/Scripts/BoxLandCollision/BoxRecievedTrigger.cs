using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]  
public class TriggerEvent : MonoBehaviour
{

    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent AddPoints;
    Rigidbody rb;
    BoxCollider boxCol;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        boxCol = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponentInParent<BoxScript>() != null)
        {
            Debug.Log("HIT");
            OnTriggerEnterEvent.Invoke();
            if(other.GetComponentInParent<BoxScript>().IsCat == true){
                AddPoints.Invoke();
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            boxCol = GetComponent<BoxCollider>();
        }

        Gizmos.color = new Color(0, 1, 1, 0.5f);
        Gizmos.DrawCube(transform.position, boxCol.size);
    }
}
