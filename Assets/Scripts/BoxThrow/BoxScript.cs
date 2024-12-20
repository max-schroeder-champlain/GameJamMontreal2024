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

    //private float LeftOffset = -0.5f;
    //private float UpOffset = 0.25f;
    public bool canBeClicked = false;
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
    public bool GoUp = false;
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    public AudioSource hitSource;

    public GameObject handOnePos = null;
    public GameObject handTwoPos = null;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        RandomizeAudio();
    }
    private void RandomizeAudio()
    {
        int rand = Random.Range(0 , audioClips.Length);
        audioSource.clip = audioClips[rand];
    }
    private void SetHeld()
    {
        CenterPoint.instance.SetCurrentlyHeld(this.gameObject);
        //rb.useGravity = true;
    }
    void Update()
    {
        mousePos = GameManager.Instance.mousePos;
        CheckShake();
        lastPos = mousePos;
    }
    private void FixedUpdate()
    {
        FollowMouse();
        MoveTo();
        GetLastVelocity();
    }
    private void GetLastVelocity()
    {
        if (!setToMouse) return;
        lastPositions[velocityIndex % lastPositions.Length] = transform.position;
        velocityIndex++;
    }
    private void CheckShake()
    {
        if (!setToMouse) return;
        if(!IsCat) return;
        if(Vector3.Distance(lastPos, mousePos) > 0.2f)
        {
            Debug.Log("Shaking");
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            } 
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
        
        setToMouse = false;
        CheckVelocity();
    }
    private void CheckVelocity() // no longer has anything to do with velocity :)
    {
        if (GoLeft && !thrown)
        {
            thrown = true;
            ThrowLeft();
        }
        if (GoUp && !thrown)
        {
            thrown = true;
            ThrowUp();
        }
        if(!thrown)
        {
            //CenterPoint.instance.SetCurrentlyHeld(this.gameObject);
            Moving = true;
        }
    }
    private void ThrowUp()
    {
        Debug.Log("ThrownUp");
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        //rb.velocity = new Vector3(rb.velocity.x, Mathf.Abs(rb.velocity.y), rb.velocity.z);
        rb.AddForce(new Vector3(0, 150, 500));
        canBeClicked = false;
        //GameManager.Instance.SetCursorLocked();
        CenterPoint.instance.SetCanCreate(true);
    }
    private void ThrowLeft()
    {
        rb.useGravity = true;
        CenterPoint.instance.ReleaseHeld();
        rb.velocity = new Vector3(-(rb.velocity.x+7), rb.velocity.y, rb.velocity.z);
        canBeClicked = false;
        StartCoroutine(ToBeDeleted());
        CenterPoint.instance.StartTimer();
        CenterPoint.instance.SetCanCreate(true);
        //GameManager.Instance.SetCursorLocked();
    }
    private IEnumerator ToBeDeleted()
    {
        yield return new WaitForSeconds(timeBeforeDestroy*.5f);
        CenterPoint.instance.CauseFire(IsCat);
        yield return new WaitForSeconds(timeBeforeDestroy * .5f);
        OnThrownLeft.Invoke();
        Destroy(this.gameObject);
    }
    public void MoveToStart(Vector3 startPos)
    {
        StartPos = startPos;
        Moving = true;
        lastPositions = new Vector3[5];
        for (int i = 0; i < lastPositions.Length; i++)
        {
            lastPositions[i] = startPos;
        }
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
        if(collision.gameObject.tag == "Ground") // maybe add barrier????
        {
            Instantiate(VFXprefab, collision.contacts[0].point, Quaternion.identity);
        }
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Barrier")
        {
            hitSource.Play();
        }
    }
    private void SetHands()
    {
        GameManager.Instance.SetHandPos(handOnePos, handTwoPos);
    }
}
