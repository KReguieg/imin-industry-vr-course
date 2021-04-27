using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MachineController : MonoBehaviour
{
    private AudioSource audioSource;

    private int batteryLevel;

    public UnityEvent OnMachineStarted;

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
        OnMachineStarted.Invoke();
    }
}
