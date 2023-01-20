using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (prefab != null && spawnPoint != null)
        {
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
        Destroy(gameObject);
    }
}