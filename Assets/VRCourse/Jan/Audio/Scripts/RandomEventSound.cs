using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomEventSound : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioMixerGroup output;
    public AudioSource source;
    public float minPitch = .95f;
    public float maxPitch = 1.05f;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void PlayRandomSound()
    {
        int randomClip = Random.Range(0, clips.Length);
        source.clip = clips[randomClip];
        source.outputAudioMixerGroup = output;
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
    }
}
