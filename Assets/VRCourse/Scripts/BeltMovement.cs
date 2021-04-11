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
        if(other.gameObject.name == "XRRig")
        {
            objectToMove = other.gameObject;
            activateBeltMovement = true;
        }
    }
}
