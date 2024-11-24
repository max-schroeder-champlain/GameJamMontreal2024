using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WorldMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isMoving;
    public GameObject BoxCenter;
    public GameObject NewBoxSpawn;
    public GameObject LeftThrow;
    public UnityEvent OnFinishedMoving;
    private Vector3 OldCameraPos;
    private AudioSource audioSource;
    public AudioClip driving;
    public AudioClip stopping;
    private int MoveNum = 0;

    private Vector3 startPos;
    private Vector3 endPos;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(WaitFrame());
    }
    private IEnumerator WaitFrame()
    {
        yield return null;
        OnFinishedMoving.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MovePlayer();
        }


    }

    public void MoveThePlayer()
    {
        MoveNum++;
        if(MoveNum >= 9)
        {
            SceneManager.LoadScene("ResultsScreen");
        }
        startPos = this.transform.position;
        audioSource.clip = driving;
        if(!audioSource.isPlaying)
            audioSource.Play();
        OldCameraPos = this.gameObject.transform.position;
        isMoving = true;
        StartCoroutine(MovementWaitTime());
    }
    private void MovePlayer()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 5 * Time.deltaTime, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
    IEnumerator MovementWaitTime()
    {
        yield return new WaitForSeconds(3);
        isMoving = false;
        BoxCenter.transform.position= new Vector3 (BoxCenter.transform.position.x + (this.gameObject.transform.position.x - OldCameraPos.x), BoxCenter.transform.position.y, BoxCenter.transform.position.z);
        NewBoxSpawn.transform.position = new Vector3(NewBoxSpawn.transform.position.x + (this.gameObject.transform.position.x - OldCameraPos.x), NewBoxSpawn.transform.position.y, NewBoxSpawn.transform.position.z);
        LeftThrow.transform.position = new Vector3(LeftThrow.transform.position.x + (this.gameObject.transform.position.x - OldCameraPos.x), LeftThrow.transform.position.y, LeftThrow.transform.position.z);
        audioSource.clip = stopping;
        if(audioSource.isPlaying)
        {
            audioSource.Play();
        }
        OnFinishedMoving.Invoke();
        endPos = this.gameObject.transform.position;
        Debug.Log(startPos.x - endPos.x);
    }
}
