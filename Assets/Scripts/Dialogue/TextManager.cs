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

    public string[] Text = {
    "House1",
    "Ugh. Haven't forgiven them for licorice on Halloween.",
    "House2",
    "Ha, that stupid mower was so loud on Sunday's.",
    "House3",
    "I wonder if those twerps ever grew out of sucking... ",
    "House4",
    "Every town has their crazy cat lady.",
    "House5",
    "One time they had a penguin move in. Weird.",
    "House6",
    "She was miserable and took it out on me. Arsehole.",
    "House7",
    "Felt like there was a new rumor every day about that place.",
    "House8",
    "Yikes, hope the bachelor pad is fun, at least.",
    "House9",
    "We're still friends on Facebook, haha",
    "House10",
    "Them and their pool were such a hit in the summertime."};
    private void Awake()
    {
        /*string path = Application.dataPath + "/Text/voicelinetext.txt";
        Debug.Log(path); 
        if (!File.Exists(path))
        {
            Debug.Log("ERROR! NO PATH"); 
            this.enabled = false;
        }
        textReader = new StreamReader(path);*/
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
    }

    public void SetCurrentDialogue(DialogueScript temp)
    {
        if (currentDialogue == null)
        {
            currentDialogue = temp;
        }
        Debug.Log("go");
        //currentDialogue.SetText(); 

    }

    public string ReadAtKey(string key)
    {
/*        while (!textReader.EndOfStream)
        {
            if (textReader.ReadLine()==key)
            {
                string text = textReader.ReadLine();
                return text; 
            }
        }*/
        for(int i = 0; i < Text.Length; i++)
        {
            if(Text[i] == key)
            {
                return Text[i+1];
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
