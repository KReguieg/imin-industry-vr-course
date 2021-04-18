using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramRotation : MonoBehaviour
{
    private float xAngle=0.0f;
    private float yAngle;
    private float zAngle=0.0f;
    public float rotationSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        yAngle = Time.deltaTime * rotationSpeed;
        gameObject.transform.Rotate(xAngle, yAngle, zAngle);
    }
}
