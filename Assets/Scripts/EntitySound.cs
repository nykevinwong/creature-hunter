using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  class EntitySound : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();
    public AudioClip fallingSoundClip;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(int index)
    {
        if (index < 0 || index >= audioClips.Count)
        {
            Debug.LogWarning($"no such sound index for entity {index}");
            return;
        }
        audioSource.PlayOneShot(audioClips[index], 0.3f);
    }
    
    public void PlayRandom()
    {
        PlaySound(UnityEngine.Random.Range(0, audioClips.Count-1));
    }

    public void PlayFallingSound()
    {
        if (fallingSoundClip == null) return;
        audioSource.PlayOneShot(fallingSoundClip, 0.2f);
        
    }
}
