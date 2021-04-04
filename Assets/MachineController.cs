using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MachineController : MonoBehaviour
{
    private AudioSource audioSource;

    private int batteryLevel;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void ChangeBatteryLevel(int amount)
    {
        batteryLevel += amount;

        if (batteryLevel >= 3)
            StartMachine();
    }

    private void StartMachine()
    {
        audioSource.Play();
        FindObjectOfType<ElevatorController>().PowerOnElevator();
    }
}
