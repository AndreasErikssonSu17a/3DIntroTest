using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public bool invert;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.Rotate(Vector3.right,
            invert? Input.GetAxis("Mouse Y"): -Input.GetAxis("Mouse Y"), 
            Space.Self);
    }
}
