using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class ControlRoomFPSController : MonoBehaviour
{

    public float sensitivity = 2.0f;
    public float smooth = 0.1f;
    public float yawMin = -90f;
    public float yawMax = 90f;
    public float pitchMin = -30f;
    public float pitchMax = 30f;

    float yaw = 0.0f;
    float pitch = 0.0f;
    Vector3 desiredRotation;
    Vector3 currentRotation;

    void Start()
    {
        Assert.IsTrue(smooth > 0f, "Smooth must be greater than 0");
        desiredRotation = transform.eulerAngles;
        currentRotation = transform.eulerAngles;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        yaw = Mathf.Clamp(yaw, yawMin, yawMax);
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        desiredRotation = new Vector3(pitch, yaw, 0.0f);
        currentRotation = Vector3.Lerp(currentRotation, desiredRotation, smooth);

        transform.eulerAngles = currentRotation;
    }
}
