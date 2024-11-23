using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPoint : MonoBehaviour
{
    public static CenterPoint instance;
    public GameObject CurrentlyHeld = null;
    private SpringJoint spring = null;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentlyHeld(GameObject toSet)
    {
        CurrentlyHeld = toSet;
        if(CurrentlyHeld.GetComponent<Rigidbody>() != null ) 
            spring.connectedBody = toSet.GetComponent<Rigidbody>();
    }
}
