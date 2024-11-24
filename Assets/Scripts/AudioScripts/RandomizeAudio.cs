using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] clips;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudio()
    {
        RandomizeClip();
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    private void RandomizeClip()
    {
        int rand = Random.Range(0, clips.Length);
        audioSource.clip = clips[rand];
    }
}
