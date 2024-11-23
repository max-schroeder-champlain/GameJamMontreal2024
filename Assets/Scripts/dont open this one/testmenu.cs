using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class testmenu : MonoBehaviour
{
    public void ButtonOne()
    {
        SceneManager.LoadScene("DialogueScene"); 
    }

    public void ButtonTwo()
    {
        SceneManager.LoadScene("BoxThrow"); 
    }
}
