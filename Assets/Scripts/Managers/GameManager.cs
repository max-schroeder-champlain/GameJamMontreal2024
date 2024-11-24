using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Vector3 mousePos;
    private Camera mainCamera;
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
    }
    void Update()
    {
        GetMousePos();
    }
    private void GetMousePos()
    {
        float tempX = Mouse.current.position.value.x;
        float tempY = Mouse.current.position.value.y;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(tempX, tempY, 2));
    }
}
