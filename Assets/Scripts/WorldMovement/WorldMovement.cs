using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - 5 *Time.deltaTime, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}
