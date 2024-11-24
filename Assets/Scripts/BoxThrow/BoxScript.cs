using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody))]
public class BoxScript : MonoBehaviour
{
    private Rigidbody rb;
    public bool setToMouse = false;
    private Vector3 mousePos;
    private Vector3 offset = Vector3.zero;

    public UnityEvent OnThrownLeft;

    private float LeftOffset = -0.5f;
    private float UpOffset = 0.25f;
    private bool canBeClicked = false;
    private float timeBeforeDestroy = 1.5f;

    private Vector3 StartPos = Vector3.zero;
    private bool Moving = false;

    private float speed = 5;

    public GameObject VFXprefab;
    public bool IsCat = false;

    private Vector3 lastPos = Vector3.zero; 
    private bool thrown = false;
    private int velocityIndex = 0;
    private Vector3[] lastPositions;
    public bool GoLeft = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPositions = new Vector3[5];
        for(int i = 0; i < lastPositions.Length; i++)
        {
            lastPositions[i] = transform.position;
        }
    }
    private void SetHeld()
    {
        CenterPoint.instance.SetCurrentlyHeld(this.gameObject);
        rb.useGravity = true;
    }
    // Update is called once per frame
    void Update()
    {
        mousePos = GameManager.Instance.mousePos;
        FollowMouse();
        MoveTo();
        CheckShake();
        lastPos = mousePos;
        GetLastVelocity();
    }
    private void GetLastVelocity()
    {
        lastPositions[velocityIndex % lastPositions.Length] = transform.position;
        velocityIndex++;
    }
    private void CheckShake()
    {
        if (!setToMouse) return;
        if(!IsCat) return;
        if(Vector3.Distance(lastPos, mousePos) > 0.4f)
        {
            Debug.Log("Shaking");
            //Play Meow Sound
        }
    }
    private void FollowMouse()
    {
        if (!setToMouse) return;
        this.transform.position = mousePos + offset;
    }
    private void OnMouseDown()
    {
        if(!canBeClicked) return;
        rb.useGravity = false;
        offset = transform.position - mousePos;
        setToMouse = true;
        CenterPoint.instance.ReleaseHeld();
    }
    private void OnMouseUp()
    {
        if (!canBeClicked) return;
        rb.useGravity = true;
        setToMouse = false;
        CheckVelocity();
    }
    private void CheckVelocity()
    {
        Vector3 pos = CenterPoint.instance.CenterPos;
        
       
        Vector3 vel = Vector3.zero;
        for (int i = 0; i < lastPositions.Length; i++)
        {
            vel = lastPositions[i];
        }
        vel /= lastPositions.Length;
        float dot = Vector3.Dot(vel.normalized, Vector3.up);
        if (GoLeft && !thrown) //REPlACE WITH COLLIDER!!!!
        {
            thrown = true;
            ThrowLeft();
        }
        if (dot >= .04 && !thrown)
        {
            thrown = true;
            ThrowUp();
        }
        if(!thrown)
        {
            CenterPoint.instance.SetCurrentlyHeld(this.gameObject);
        }
    }
    private void ThrowUp()
    {

        rb.constraints = RigidbodyConstraints.None;
        rb.velocity = new Vector3(rb.velocity.x, Mathf.Abs(rb.velocity.y), rb.velocity.z);
        rb.AddForce(new Vector3(0, 0, 500));
        canBeClicked = false;
        //CenterPoint.instance.StartTimer();
    }
    private void ThrowLeft()
    {
        CenterPoint.instance.ReleaseHeld();
        rb.velocity = new Vector3(-(rb.velocity.x+7), rb.velocity.y, rb.velocity.z);
        canBeClicked = false;
        StartCoroutine(ToBeDeleted());
       CenterPoint.instance.StartTimer();
    }
    private IEnumerator ToBeDeleted()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        OnThrownLeft.Invoke();
        Destroy(this.gameObject);
    }
    public void MoveToStart(Vector3 startPos)
    {
        StartPos = startPos;
        Moving = true;
    }
    private void MoveTo()
    {
        if (!Moving) return;
        transform.position = Vector3.Lerp(this.transform.position, StartPos, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, StartPos) <= 0.01f)
        {
            Moving = false;
            canBeClicked = true;
            SetHeld();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Instantiate(VFXprefab, collision.contacts[0].point, Quaternion.identity);
        }
    }
}
