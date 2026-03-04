using UnityEngine;

public class PulsingText : MonoBehaviour
{
    public float pulseSpeed = 4f;
    public float minScale = 0.95f;
    public float maxScale = 1.05f;

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);
        transform.localScale = initialScale * scale;
    }
}