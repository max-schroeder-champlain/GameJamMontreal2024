using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsToTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
