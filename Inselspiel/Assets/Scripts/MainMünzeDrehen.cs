using UnityEngine;

public class MainMünzeDrehen : MonoBehaviour
{
    private float rotationSpeed = 80f;

    private float floatHeight = 0.2f;
    private float floatSpeed = 1.5f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
