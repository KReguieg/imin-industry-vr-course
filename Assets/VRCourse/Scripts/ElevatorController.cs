using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ElevatorController : MonoBehaviour
{
    private XRRig XRRig;
    [SerializeField] private GameObject movingPlatform;
    private bool hasPower;

    private Animator animator;

    void Start()
    {
        XRRig = FindObjectOfType<XRRig>();
        animator = movingPlatform.GetComponent<Animator>();
    }


    public void PowerOnElevator()
    {
        Debug.Log("Elevator is on");
    }

    public void MoveElevator()
    {
        XRRig.transform.SetParent(movingPlatform.transform);
        animator.SetTrigger("StartElevator");
    }
}
