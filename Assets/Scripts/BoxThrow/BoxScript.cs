using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoxScript : MonoBehaviour
{
    private Rigidbody rb;
    public bool setToMouse = false;
    private Vector3 mousePos;
    private Vector3 offset = Vector3.zero;

    private float LeftOffset = -0.5f;
    private float UpOffset = 0.25f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CenterPoint.instance.SetCurrentlyHeld(this.gameObject);
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = GameManager.Instance.mousePos;
        FollowMouse();
    }
    private void FollowMouse()
    {
        if (!setToMouse) return;
        this.transform.position = mousePos + offset;
    }
    private void OnMouseDown()
    {
        offset = transform.position - mousePos;
        setToMouse = true;
        CenterPoint.instance.LoosenSpring();
    }
    private void OnMouseUp()
    {
        
        setToMouse = false;
        CheckVelocity(rb.velocity);
    }
    private void CheckVelocity(Vector3 velocity)
    {
        Vector3 pos = CenterPoint.instance.CenterPos;
        Debug.Log(transform.position);
        
        Debug.Log("UpOffset = " + (pos.y+UpOffset));
        if (transform.position.x <= pos.x + LeftOffset)
        {
            Debug.Log("Left");
            ThrowLeft();
        }
        else if (transform.position.y >= pos.y + UpOffset)
        {
            Debug.Log("Up");
            ThrowUp();
        }
        else
        {
            CenterPoint.instance.TightenSpring();
        }
        
    }
    private void ThrowUp()
    {
        CenterPoint.instance.ReleaseHeld();
        Debug.Log("Velocity " + rb.velocity);
        rb.velocity = new Vector3(rb.velocity.x, Mathf.Abs(rb.velocity.y), rb.velocity.z);
        rb.AddForce(new Vector3(0, 0, 500));
    }
    private void ThrowLeft()
    {
        CenterPoint.instance.ReleaseHeld();
        rb.velocity = new Vector3(-(rb.velocity.x+7), rb.velocity.y, rb.velocity.z);
        Debug.Log("Left " + rb.velocity);
        
    }
}
