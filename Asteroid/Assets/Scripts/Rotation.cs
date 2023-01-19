using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 10, 0);
    public float accelerationTime = 10.0f;

    private float startTime;
    private Vector3 currentRotationSpeed;

    void Start()
    {
        startTime = Time.time;
        currentRotationSpeed = rotationSpeed;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float acceleration = elapsedTime / accelerationTime;

        transform.Rotate(currentRotationSpeed * Time.deltaTime);
        currentRotationSpeed = Vector3.Lerp(rotationSpeed, rotationSpeed * 2, acceleration);
    }
}
