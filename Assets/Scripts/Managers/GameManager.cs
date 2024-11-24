using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Vector3 mousePos;
    private Camera mainCamera;
    public GameObject handOne;
    public GameObject handTwo;
    public GameObject handPosOne;
    public GameObject handPosTwo;
    public GameObject PauseCanvas;
    public UnityEvent ResetBoxPos;
    private PlayerInput playerInput;
    private bool isPaused = false;
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
        playerInput = GetComponent<PlayerInput>();
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

    void OnPause(InputValue Input)
    {
        if (!isPaused)
        {
            isPaused = true;
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;

        }
        else if (isPaused)
        {
            isPaused=false;
            PauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void OnResetBox(InputValue Input)
    {
        ResetBoxPos.Invoke();
    }
}
