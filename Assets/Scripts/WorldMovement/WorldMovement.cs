using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isMoving;
    void Start()
    {
        StartCoroutine(MovementWaitTime());
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
        isMoving = true;
    }
    private void MovePlayer()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 5 * Time.deltaTime, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
    IEnumerator MovementWaitTime()
    {
        yield return new WaitForSeconds(3);
        isMoving = false;
    }
}
