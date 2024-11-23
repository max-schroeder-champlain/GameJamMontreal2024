using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System.ComponentModel;

public class TextManager : MonoBehaviour
{
    public static TextManager instance = null;
    private DialogueScript currentDialogue = null;
    private StreamReader textReader = null;
    private TextAsset textAsset = null;

    private void Awake()
    {
        string path = Application.dataPath + "/Text/voicelinetext.txt";
        Debug.Log(path); 
        if (!File.Exists(path))
        {
            Debug.Log("ERROR! NO PATH"); 
            this.enabled = false;
        }
        textReader = new StreamReader(path);
    }

    private void OnEnable()
    {
        if (instance == null)
        {
            Debug.Log("Instance Created"); 
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this); 
        }
    }

    private void OnDisable()
    {
        if (instance != null && instance == this)
        {
            instance = null; 
        }
        textReader.Close();
    }

    public void SetCurrentDialogue(DialogueScript temp)
    {
        if (currentDialogue == null)
        {
            currentDialogue = temp;
        }
        Debug.Log("go");
        currentDialogue.SetText(); 

    }

    public string ReadAtKey(string key)
    {
        while (!textReader.EndOfStream)
        {
            if (textReader.ReadLine() == key)
            {
                string text = textReader.ReadLine();
                return text; 
            }
        }
        return "fuck"; 
    }

    public void NextDialogue()
    {
        if (currentDialogue == null) return; 
        if (currentDialogue.typing)
        {
           currentDialogue.SkipType();
            return; 
        }
        currentDialogue.SetText(); 
    }
}
