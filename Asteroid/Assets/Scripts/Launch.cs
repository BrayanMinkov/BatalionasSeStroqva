using System.Collections;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 spawnLocation;
    public Vector3 shootDirection;
    public float force = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnLocation, Quaternion.identity);
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(shootDirection * force, ForceMode.Impulse);
            }
        }
    }
}