﻿using UnityEngine;

public class ARImageTracker : MonoBehaviour
{
    [SerializeField] private GameObject ARObjectPrefab = null;
    [SerializeField] private GameObject ARCamera = null;
    [SerializeField] private LayerMask layerMask;
    private bool instantiated = false;

    RaycastHit hit;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cameraOrigin = ARCamera.transform.position;
        Vector3 rayDirection = ARCamera.transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(cameraOrigin, rayDirection, Color.yellow);
        if (Physics.Raycast(cameraOrigin, rayDirection, out hit, 10.0f, layerMask))
        {
            if (!instantiated)
            {
                GameObject spawnedARObject = Instantiate(ARObjectPrefab, hit.transform);
                spawnedARObject.transform.localScale = Vector3.one;

                spawnedARObject.transform.position += Vector3.up * 0.25f;
                instantiated = true;
            }
        }
    }
}