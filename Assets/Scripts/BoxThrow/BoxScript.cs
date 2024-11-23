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
        Debug.Log(velocity);
        if (velocity.x >= 2)
        {
            Debug.Log("Left");
            ThrowLeft();
        }
        else if (velocity.y >= 2)
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
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y/2, rb.velocity.z*3);
        rb.AddForce(new Vector3(0, -rb.velocity.y/2, 100));
    }
    private void ThrowLeft()
    {
        rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
        CenterPoint.instance.ReleaseHeld();
    }
}
