using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMovement : MonoBehaviour
{
    [SerializeField] private Transform targetPosition = null;
    private bool activateBeltMovement = false;
    private GameObject objectToMove = null;

    private void Update()
    {
        if (activateBeltMovement)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, targetPosition.position, 0.01f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "XRRigDemo")
        {
            objectToMove = other.gameObject;
            activateBeltMovement = true;
        }
    }
}
