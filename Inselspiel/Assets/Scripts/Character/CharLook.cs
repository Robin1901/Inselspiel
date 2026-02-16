using UnityEngine;

public class CharLook : MonoBehaviour
{
    [SerializeField] private Transform headPos;

    // Ersetze Update durch LateUpdate für eine flüssige Kamera
    void LateUpdate()
    {
        if (headPos != null)
        {
            transform.position = headPos.position;
        }
    }
}