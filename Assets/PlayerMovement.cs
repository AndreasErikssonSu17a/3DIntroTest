using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        controller.SimpleMove(transform.forward * moveSpeed * Input.GetAxis("Vertical"));
        controller.SimpleMove(transform.right * moveSpeed * Input.GetAxis("Horizontal"));

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"), Space.World);
    }
}
