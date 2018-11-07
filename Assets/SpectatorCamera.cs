using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SpectatorCamera : MonoBehaviour
{
    [Range(0.1f, 50f)]
    public float moveSpeed = 8f;

    [Range(0.01f, 100f)]
    public float sensitivity = 1f;

    private Camera cam;

    [Range(5f, 60f)]
    public float zoomedInFOV = 25f;
    private float defaultFOV;

    void Start()
    {
        cam = GetComponent<Camera>();

        defaultFOV = cam.fieldOfView;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = zoomedInFOV;
        }
        if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = defaultFOV;
        }

        transform.position += transform.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.position += transform.up * moveSpeed * Time.deltaTime * Input.GetAxis("Lift");

        transform.position += transform.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * sensitivity * Input.GetAxis("Mouse X"), Space.World);

        transform.Rotate(Vector3.right * sensitivity * -Input.GetAxis("Mouse Y"), Space.Self);
    }
}
