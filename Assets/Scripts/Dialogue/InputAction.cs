using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAction : MonoBehaviour
{
     void OnSkip(InputValue input)
    {
        Debug.Log("im clicked"); 
        TextManager.instance.NextDialogue(); 
    }
}