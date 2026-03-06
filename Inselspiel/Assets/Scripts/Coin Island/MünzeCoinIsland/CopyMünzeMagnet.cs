using UnityEngine;

public partial class CopyMünzeMagnet : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Transform targetPlayer;

    void Update()
    {
        if (targetPlayer != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
        }
    }

    public void StartMagnet(Transform playerTransform)
    {
        targetPlayer = playerTransform;
    }
}