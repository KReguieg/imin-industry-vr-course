using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class RobotSoundManager : MonoBehaviour
{

    public static RobotSoundManager Instance;

    [SerializeField] private List<RobotSounds> robotSounds = new List<RobotSounds>();

    private AudioSource audioSource;

    private int currentClip;

    private RobotSounds currentRoom;

    public void PlayNextClip()
    {
        if (currentClip >= currentRoom.sounds.Count)
            return;

        audioSource.clip = currentRoom.sounds[currentClip++];
        audioSource.Play();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

        audioSource = GetComponent<AudioSource>();
    }


    public void SetRoom(int RoomID)
    {
        currentRoom = robotSounds[RoomID];
    }
}
