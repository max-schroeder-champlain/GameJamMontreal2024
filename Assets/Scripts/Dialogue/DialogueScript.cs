using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 


public class DialogueScript : MonoBehaviour
{
    public TMP_Text Name = null;
    public TMP_Text DialogueText = null;
    public string CharacterName = null;
    public string[] TextKeys = null;
    private int arrayIndex = 0;
    private int arrayMax;
    private float delayTime = 0.05f;
    public bool typing = false;
    public GameObject box;
    public AudioClip[] audioclips;
    private AudioSource audioSource;


    private void Start()
    {
        //Name.text = CharacterName;
        arrayMax = TextKeys.Length;
        TextManager.instance.SetCurrentDialogue(this);
        box.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void SetText()
    {
        if (arrayIndex == arrayMax) return;
       StartCoroutine(Typewriting(TextManager.instance.ReadAtKey(TextKeys[arrayIndex])));
        audioSource.clip = audioclips[arrayIndex];
        audioSource.Play();
        arrayIndex++;

    }

    private IEnumerator Typewriting(string textToWrite)
    {
        box.SetActive(true);
        typing = true;

        for (int i =0; i <= textToWrite.Length; i++)
        {
            DialogueText.text = textToWrite.Substring(0, i); 
            yield return new WaitForSeconds(delayTime/1.45f);
            if (!typing)
            {
                DialogueText.text = textToWrite;
                break; 
            }
        }
        typing = false;
        yield return new WaitForSeconds(1.5f);
        box.SetActive(false);  
    }

    public void SkipType()
    {
        typing = false; 
    }
}
