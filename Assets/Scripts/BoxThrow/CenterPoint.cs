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
    public CreateNewBox CreateNewBox = null;
    public float TimeToWait = 1.5f;
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
    private void Start()
    {
        StartCoroutine(WaitForNewSpawn());
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
        TightenSpring();
        StartCoroutine(WaitForNewSpawn());
    }
    public void LoosenSpring()
    {
        spring.maxDistance = LoosenedTolerance;
        spring.tolerance = LoosenedTolerance;
    }
    public void TightenSpring()
    {
        spring.maxDistance = 0f;
        spring.tolerance = startingTolerance;
    }

    private IEnumerator WaitForNewSpawn()
    {
        yield return new WaitForSeconds(TimeToWait);
        if(CreateNewBox != null)
            CreateNewBox.CreateBox();
    }    
}
