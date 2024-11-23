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
        spring.tolerance = LoosenedTolerance;
    }
    public void TightenSpring()
    {
        spring.tolerance = startingTolerance;
    }
}
