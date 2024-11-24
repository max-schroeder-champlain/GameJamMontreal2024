using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Game Start"); 
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Credits Opened"); 
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void TutorialStart()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Game Begin"); 
    }

    public void CreditsBack()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu"); 
    }
}
