using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LocalNeighborhood");
        Debug.Log("Game Start"); 
    }

    public void CreditsMenu()
    {
        //SceneManager.LoadScene("CreditsMenu");
        Debug.Log("Credits Opened"); 
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void TutorialStart()
    {
        SceneManager.LoadScene("LocalNeighborhood");
        Debug.Log("Game Begin"); 
    }
}
