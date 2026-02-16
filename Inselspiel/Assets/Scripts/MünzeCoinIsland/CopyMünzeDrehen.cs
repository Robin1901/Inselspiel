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

            // Start-Z merken
            currentZ = transform.eulerAngles.z;
        }
    }

    void FixedUpdate()
    {
        if (landed)
        {
            transform.position = landedPosition;

            transform.rotation = Quaternion.Euler(-90f, 0f, currentZ);

            currentZ += spinSpeed * Time.fixedDeltaTime;


        }
    }
}
