using UnityEngine;
using UnityEngine.SceneManagement;

public class SetActiveCamera : MonoBehaviour
{
    public Camera newCamera;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Camera.main.enabled = false;
        newCamera.enabled = true;
    }
}

