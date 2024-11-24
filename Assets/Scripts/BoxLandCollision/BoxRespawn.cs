using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxRespawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject CenterPoint;
    public UnityEvent ResetBoxPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            Destroy(other.gameObject);
            ResetBoxPos.Invoke();
        }
    }
}
