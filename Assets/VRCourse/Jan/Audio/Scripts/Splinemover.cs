using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splinemover : MonoBehaviour
{
    public Spline spline;
    public Transform followObj;
    private Transform thisTransform;
 
    void Start()
    {
        thisTransform = transform;
    }


    void Update()
    {
        thisTransform.position = spline.WhereOnSpline(followObj.position);
    }
}
