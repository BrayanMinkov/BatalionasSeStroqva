using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera newCamera;
    public float changeTime = 10f; // Change camera after 10 seconds

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime >= changeTime)
        {
            mainCamera.enabled = false;
            newCamera.enabled = true;
        }
    }
}
