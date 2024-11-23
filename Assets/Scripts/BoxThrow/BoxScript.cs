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
        //rb.useGravity = true;
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
        this.transform.position = mousePos;
    }
    private void OnMouseDown()
    {
        Debug.Log("Grabbed");
        offset = transform.position - mousePos;
        setToMouse = true;
    }
    private void OnMouseUp()
    {
        Debug.Log("Released");
        setToMouse = false;
    }
}
