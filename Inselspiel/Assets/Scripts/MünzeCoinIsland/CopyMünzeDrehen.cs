using UnityEngine;

public class CopyMünzeDrehen : MonoBehaviour
{
    private float spinSpeed = 100f;

    private Rigidbody rb;
    private bool landed = false;
    private Vector3 landedPosition;

    private float currentZ = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = true;
        rb.isKinematic = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!landed && collision.gameObject.CompareTag("Ground"))
        {
            landed = true;

            landedPosition = transform.position;

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;

            currentZ = transform.eulerAngles.z;
        }
    }

    void FixedUpdate()
    {
        if (landed)
        {
            transform.position = landedPosition;

            transform.Rotate(0f, 0f, spinSpeed * Time.fixedDeltaTime, Space.Self);
        }
    }

}
