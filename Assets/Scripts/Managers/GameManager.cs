using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Vector3 mousePos;
    private Camera mainCamera;
    public GameObject handOne;
    public GameObject handTwo;
    public GameObject handPosOne;
    public GameObject handPosTwo;
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    void Start()
    {
        mainCamera = Camera.main;
        SetCursorLocked();
    }
    void Update()
    {
        GetMousePos();
    }
    private void FixedUpdate()
    {
        if(handPosOne!= null && handPosTwo != null)
        {

        }
    }
    private void GetMousePos()
    {
        float tempX = Mouse.current.position.value.x;
        float tempY = Mouse.current.position.value.y;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(tempX, tempY, 2));
    }
    public void SetCursorLocked()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void SetCursorConfined()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void SetHandPos(GameObject one, GameObject two)
    {
        handPosOne = one;
        handPosTwo = two;
    }
}
