using UnityEngine;

public class SkyhookEarthRotation : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 10f;

    void Update()
    {
        transform.RotateAround(target.position, target.up, rotationSpeed * Time.deltaTime);
    }
}
