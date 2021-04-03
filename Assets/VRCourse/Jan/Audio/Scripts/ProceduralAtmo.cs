using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ProceduralAtmo : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioMixerGroup output;

    public float minPitch = .95f;
    public float maxPitch = 1.05f;
    public int timebetweenclips;
    private int routine = 1;

    public AudioSource source;

    void Start()
    {

    }

    void Update()
    {
        if (!source.isPlaying && routine == 1)
        {
            StartCoroutine(Sound());
        }
    }

    IEnumerator Sound()
    {

        routine = 0;

        yield return new WaitForSecondsRealtime(timebetweenclips);
            int randomClip = Random.Range(0, clips.Length);
            source.clip = clips[randomClip];
            source.outputAudioMixerGroup = output;
            source.pitch = Random.Range(minPitch, maxPitch);
            source.Play();

        yield return new WaitForSecondsRealtime(source.clip.length);
            routine = 1;

        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        
    }
}
