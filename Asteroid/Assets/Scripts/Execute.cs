using UnityEngine;
using UnityEngine.Animations;

public class Execute : MonoBehaviour
{
public MonoBehaviour scriptToStart1;
public MonoBehaviour scriptToStart2;
public GameObject objectToDestroy;
public GameObject objectToAnimate1;
public GameObject objectToAnimate2;
public string animationTrigger1;
public string animationTrigger2;
public float stopTime = 180f; // 3 minutes in seconds

private float startTime;
private bool started = false;

void Update()
{
    if (Input.GetKeyDown(KeyCode.Space) && !started)
    {
        scriptToStart1.enabled = true;
        scriptToStart2.enabled = true;
        started = true;
        startTime = Time.time;
    }

    if (started && Time.time - startTime >= stopTime)
    {
        scriptToStart1.enabled = false;
        scriptToStart2.enabled = false;
        started = false;
        Destroy(objectToDestroy);
        objectToAnimate1.GetComponent<Animator>().SetTrigger(animationTrigger1);
        objectToAnimate2.GetComponent<Animator>().SetTrigger(animationTrigger2);
    }
}
}