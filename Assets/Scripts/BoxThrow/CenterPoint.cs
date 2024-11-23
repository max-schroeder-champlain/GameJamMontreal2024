using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPoint : MonoBehaviour
{
    public static CenterPoint instance;
    public GameObject CurrentlyHeld = null;
    private SpringJoint spring = null;
    private float startingTolerance = 0;
    public float LoosenedTolerance = 10;
    public Vector3 CenterPos = Vector3.zero;
    private void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDisable()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        spring = GetComponent<SpringJoint>();
        startingTolerance = spring.tolerance;
        CenterPos = transform.position;
        Debug.Log(CenterPos);
    }
    public void SetCurrentlyHeld(GameObject toSet)
    {
        if (CurrentlyHeld != null) return;
        CurrentlyHeld = toSet;
        if(CurrentlyHeld.GetComponent<Rigidbody>() != null ) 
            spring.connectedBody = toSet.GetComponent<Rigidbody>();
    }
    public void ReleaseHeld()
    {
        spring.connectedBody = null;
        CurrentlyHeld = null;
    }
    public void LoosenSpring()
    {
        spring.maxDistance = LoosenedTolerance;
        spring.tolerance = LoosenedTolerance;
    }
    public void TightenSpring()
    {
        spring.maxDistance = 0.25f;
        spring.tolerance = startingTolerance;
    }
}
