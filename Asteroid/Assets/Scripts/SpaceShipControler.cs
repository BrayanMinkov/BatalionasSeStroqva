using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControler : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float thrust = 5.0f;
    public float drag = 0.95f;
    public float mouseSensitivity = 5.0f;

    private Rigidbody rb;
    private float mouseX;
    private float mouseY;
    private bool isHoldingRightClick = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move forward and backward
        rb.AddForce(transform.forward * verticalInput * speed);

        // Rotate left and right
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // Apply drag to slow down over time
        rb.velocity *= drag;

        if (Input.GetMouseButtonDown(1))
        {
            isHoldingRightClick = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isHoldingRightClick = false;
        }

        if (isHoldingRightClick)
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            // Rotate the ship around the x-axis
            transform.Rotate(Vector3.right, mouseY * mouseSensitivity * Time.deltaTime, Space.Self);
            // Rotate the ship around the y-axis
            transform.Rotate(Vector3.up, mouseX * mouseSensitivity * Time.deltaTime, Space.Self);
        }
    }
}