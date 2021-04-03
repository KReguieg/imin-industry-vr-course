using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomClipPlay : MonoBehaviour
{

    public AudioClip[] clips;
    public AudioMixerGroup output;

    public float minPitch = .95f;
    public float maxPitch = 1.05f;
    public string button;

    public AudioSource source;
   
    void Start()
    {

    }
  
    void Update()
    {
        if(Input.GetKeyDown(button))
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        int randomClip = Random.Range(0, clips.Length);
        source.clip = clips[randomClip];
        source.outputAudioMixerGroup = output;
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();

    }
}
