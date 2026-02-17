using UnityEngine;

public class CopyMünzeDrehen : MonoBehaviour
{
    private float spinSpeed = 100f;
    private float groundCheckDistance = 0.7f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool landed = false;
    private float currentZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        if (!landed)
        {
            CheckForGround();
        }
    }

    void CheckForGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            Land(hit.point);
        }
    }

    void Land(Vector3 hitPoint)
    {
        landed = true;

        rb.isKinematic = true;
        rb.useGravity = false;

        float offset = 0.4f;
        transform.position = new Vector3(hitPoint.x, hitPoint.y + offset, hitPoint.z);

        Quaternion baseRot = Quaternion.Euler(-90f, 0f, 0f);
        Quaternion relative = Quaternion.Inverse(baseRot) * transform.rotation;
        float z = relative.eulerAngles.z;
        if (z > 180f) z -= 360f;
        currentZ = z;
    }

    void Update()
    {
        if (landed)
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, currentZ);
            currentZ += spinSpeed * Time.deltaTime;
        }
    }
}