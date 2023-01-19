using UnityEngine;

public class SpaceshipControlller : MonoBehaviour
{
    public float speed = 10.0f;
    public float tiltSpeed = 4.0f;
    public float tiltAmount = 4.0f;
    public float thrust = 1.0f;
    public float drag = 0.1f;
    public float lift = 0.1f;
    public float verticalSpeed = 10.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        Quaternion target = Quaternion.Euler(moveVertical * tiltAmount, 0.0f, moveHorizontal * -tiltAmount);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * tiltSpeed);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * thrust);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rb.AddForce(transform.up * verticalSpeed);
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            rb.AddForce(transform.up * -verticalSpeed);
        }

        rb.drag = drag;
        rb.AddForce(Vector3.up * lift);
    }
}

