using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewBox : MonoBehaviour
{
    public GameObject BoxPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CenterPoint.instance.CreateNewBox = this;
    }
    public void CreateBox()
    {
        GameObject temp = Instantiate(BoxPrefab, this.transform.position, Quaternion.identity);
        Vector3 pos = CenterPoint.instance.CenterPos;
        temp.GetComponent<BoxScript>().MoveToStart(new Vector3(pos.x, pos.y - 0.5f, pos.z));
    }
}
