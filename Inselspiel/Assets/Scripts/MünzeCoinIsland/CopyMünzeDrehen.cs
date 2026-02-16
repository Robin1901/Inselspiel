using UnityEngine;

public class CopyMünzeDrehen : MonoBehaviour
{
    private float spinSpeed = 100f;

    private Rigidbody rb;
    private bool landed = false;
    private Vector3 landedPosition;

    private float currentZ;

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
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

            Quaternion baseRot = Quaternion.Euler(-90f, 0f, 0f);
            Quaternion relative = Quaternion.Inverse(baseRot) * transform.rotation;
            float z = relative.eulerAngles.z;
            if (z > 180f) z -= 360f;
            currentZ = z;
        }
    }

    void Update()
    {
        if (landed)
        {
            transform.position = landedPosition;

            transform.rotation = Quaternion.Euler(-90f, 0f, currentZ);

            currentZ += spinSpeed * Time.deltaTime;


        }
    }
}
