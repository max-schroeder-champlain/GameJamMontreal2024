using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToTitleScreen : MonoBehaviour
{
    private Button btn;
    public string TitleScreenName;
    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("To the Title Screen!");
        //SceneManager.LoadScene(MainLevelName);
    }
}
