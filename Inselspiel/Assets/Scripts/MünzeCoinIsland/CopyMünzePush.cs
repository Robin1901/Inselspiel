using UnityEngine;

public class CopyMünzePush : MonoBehaviour
{
    private float minDropForce = 0.3f;
    private float maxDropForce = 4.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        float dropForce = Random.Range(minDropForce, maxDropForce);
        rb.AddForce(transform.up * dropForce, ForceMode.Impulse);
    }
}
