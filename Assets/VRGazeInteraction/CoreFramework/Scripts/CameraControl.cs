using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            transform.Translate(Vector3.back);

        if (Input.GetKeyDown(KeyCode.E))
            transform.Translate(Vector3.forward);

        if (Input.GetKeyDown(KeyCode.W))
            transform.Translate(Vector3.up);

        if (Input.GetKeyDown(KeyCode.S))
            transform.Translate(Vector3.down);

        if (Input.GetKeyDown(KeyCode.A))
            transform.Translate(Vector3.left);

        if (Input.GetKeyDown(KeyCode.D))
            transform.Translate(Vector3.right);
    }
}
