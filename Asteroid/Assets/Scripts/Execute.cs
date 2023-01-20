using UnityEngine;

public class Execute : MonoBehaviour
{
    public MonoBehaviour scriptToStart;
    public GameObject objectToDestroy;
    public float stopTime = 180f; // 3 minutes in seconds

    private float startTime;
    private bool started = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !started)
        {
            scriptToStart.enabled = true;
            started = true;
            startTime = Time.time;
        }

        if (started && Time.time - startTime >= stopTime)
        {
            scriptToStart.enabled = false;
            started = false;
            Destroy(objectToDestroy);
        }
    }
}
