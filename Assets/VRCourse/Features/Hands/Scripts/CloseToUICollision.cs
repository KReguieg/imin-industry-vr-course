using System;
using UnityEngine;

public class CloseToUICollision : MonoBehaviour
{
    public static event Action<GameObject> OnEnterUIArea = delegate { };
    public static event Action<GameObject> OnExitUIArea = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        OnEnterUIArea?.Invoke(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        OnExitUIArea?.Invoke(gameObject);
    }
}
