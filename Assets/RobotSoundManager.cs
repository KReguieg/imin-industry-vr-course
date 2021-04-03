using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class RobotSoundManager : MonoBehaviour
{

    [SerializeField] private List<AudioClip> roomA = new List<AudioClip>();
    [SerializeField] private List<AudioClip> roomB = new List<AudioClip>();
    [SerializeField] private List<AudioClip> roomC = new List<AudioClip>();
    [SerializeField] private List<AudioClip> roomD = new List<AudioClip>();

    [SerializeField] private InputAction nextClip;

    private AudioSource audioSource;

    private int currentClip;


    public void PlayNextClip(List<AudioClip> roomClips)
    {
        if (currentClip >= roomClips.Count)
            return;

        audioSource.clip = roomClips[currentClip++];
        audioSource.Play();
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        nextClip.Enable();
        nextClip.started += OnNextClip;
    }

    public void OnNextClip(InputAction.CallbackContext context)
    {
        PlayNextClip(roomB);
    }

    private void OnDisable()
    {
        nextClip.Disable();
    }

    private void Update()
    {
        
    }
}
