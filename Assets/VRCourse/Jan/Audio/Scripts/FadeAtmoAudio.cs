using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FadeAtmoAudio : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioMixerGroup output;

    public float minPitch = .95f;
    public float maxPitch = 1.05f;
    public float FadeRatio = 0.5f;
    public float FadingTime = 5;
    private int routine = 1;
    private int Fade2start = 0;
    private int Fade1start = 0;

    public AudioSource source1;
    public AudioSource source2;

    void Start()
    {
        source1.volume = 1;
        source2.volume = 0;
    }

    void Update()
    {
        if (routine == 1)
        {
            StartCoroutine(Sound());
           
        }

        if (source1.volume != 0 && Fade2start == 1)
        {
            source1.volume -= FadeRatio * Time.deltaTime;
            source2.volume += FadeRatio * Time.deltaTime;
        }

        if (source2.volume != 0 && Fade1start == 1)
        {
            source2.volume -= FadeRatio * Time.deltaTime;
            source1.volume += FadeRatio * Time.deltaTime;
        }

    }

    IEnumerator Sound()
    {

        Debug.Log(Time.deltaTime);

        routine = 0;

        
        int randomClip = Random.Range(0, clips.Length);
        source1.clip = clips[randomClip];
        source1.outputAudioMixerGroup = output;
        source1.pitch = Random.Range(minPitch, maxPitch);
        source1.Play();
        float s1lenght = source1.clip.length - FadingTime; //fading time at the end
        float s1remaining = source1.clip.length - s1lenght; //remaining time
        Debug.Log("Fading time : " + s1remaining);
        yield return new WaitForSecondsRealtime(s1lenght);
        Fade1start = 0;
        Fade2start = 1;

        StartCoroutine(Sound2());
    }

    IEnumerator Sound2()
    {

        Debug.Log(Time.deltaTime);
        

        int randomClip = Random.Range(0, clips.Length);
        source2.clip = clips[randomClip];
        source2.outputAudioMixerGroup = output;
        source2.pitch = Random.Range(minPitch, maxPitch);
        source2.Play();
        float s1lenght = source2.clip.length - FadingTime; //fading time at the end
        float s1remaining = source2.clip.length - s1lenght; //remaining time
        Debug.Log("Fading time : " + s1remaining);
        yield return new WaitForSecondsRealtime(s1lenght);
        Fade2start = 0;
        Fade1start = 1;
        routine = 1;

    }

}


