using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float aimSpeed = 10f;
    public float normalFov = 60f;
    public float aimFov = 30f;
    public bool isAiming = false;

    private Camera mainCamera;
    private float currentFov;

    void Start()
    {
        mainCamera = Camera.main;
        currentFov = normalFov;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isAiming = true;
        }
        else
        {
            isAiming = false;
        }

        if (isAiming)
        {
            currentFov = Mathf.Lerp(currentFov, aimFov, Time.deltaTime * aimSpeed);
        }
        else
        {
            currentFov = Mathf.Lerp(currentFov, normalFov, Time.deltaTime * aimSpeed);
        }

        mainCamera.fieldOfView = currentFov;
    }
}

