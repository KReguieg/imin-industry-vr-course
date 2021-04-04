using System;
using UnityEngine;

public class CloseToUICollision : MonoBehaviour
{
    public static event Action OnEnterUIArea = delegate { };
    public static event Action OnExitUIArea = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        OnEnterUIArea?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExitUIArea?.Invoke();
    }
}
