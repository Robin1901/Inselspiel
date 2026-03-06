using UnityEngine;

public class CopyMünzePush : MonoBehaviour
{
    private float maxDropForce = 4.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        float dropForce = Random.Range(0f, maxDropForce);
        rb.AddForce(transform.up * dropForce, ForceMode.Impulse);
    }
}
