using UnityEngine;

public class BoundsScript : MonoBehaviour
{
    public float pushPower = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        var other = collision.gameObject;
        var otherRigidbody = other.GetComponent<Rigidbody>();

        if (otherRigidbody == null) return;

        var pushDirection = other.transform.position - transform.position;
        pushDirection = pushDirection.normalized;

        otherRigidbody.AddForce(pushDirection * pushPower, ForceMode.Impulse);
    }
}
