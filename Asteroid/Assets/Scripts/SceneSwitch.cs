using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class SceneSwitch : MonoBehaviour
{
public string nextScene;
public float delay = 5f; // 5 seconds delay
public GameObject fadeObject;
public string fadeTrigger;


private bool canChange = false;
private float startTime;

void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        startTime = Time.time;
        canChange = true;
    }

    if (canChange && Time.time - startTime >= delay)
    {
        fadeObject.GetComponent<Animator>().SetTrigger(fadeTrigger);
        Invoke("LoadNextScene", 1f);
    }
}

void LoadNextScene()
{
    SceneManager.LoadScene(nextScene);
}
} 