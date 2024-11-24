using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isMoving;
    public GameObject BoxCenter;
    public GameObject NewBoxSpawn;
    public UnityEvent OnFinishedMoving;
    private Vector3 OldCameraPos;
    void Start()
    {
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
        OnFinishedMoving.Invoke();
    }
}
