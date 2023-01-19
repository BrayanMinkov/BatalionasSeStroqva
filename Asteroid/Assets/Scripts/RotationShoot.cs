using System.Collections;
using UnityEngine;

public class RotationShoot : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 10, 0);
    public GameObject objectToDelete;
    public float accelerationTime = 100.0f;
    public float decelerationTime = 100.0f;

    private float startTime;
    private Vector3 currentRotationSpeed;
    private bool isRotating = true;
    private bool hasAccelerated = false;

    void Start()
    {
        startTime = Time.time;
        currentRotationSpeed = rotationSpeed;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float acceleration = elapsedTime / accelerationTime;

        if (acceleration >= 1.0f)
        {
            hasAccelerated = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isRotating = false;
                startTime = Time.time;
                Destroy(objectToDelete);
            }
        }
        if (isRotating)
        {
            transform.Rotate(currentRotationSpeed * Time.deltaTime);
            if (hasAccelerated)
            {
                float deceleration = (Time.time - startTime) / decelerationTime;
                currentRotationSpeed = Vector3.Lerp(rotationSpeed * 2, Vector3.zero, deceleration);
                if (deceleration >= 1.0f)
                {
                    isRotating = false;
                }
            }
            else
            {
                currentRotationSpeed = Vector3.Lerp(rotationSpeed, rotationSpeed * 2, acceleration);
            }
        }
    }
}