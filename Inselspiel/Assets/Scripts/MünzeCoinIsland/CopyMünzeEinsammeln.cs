using UnityEngine;

public class CopyMünzeEinsammeln : MonoBehaviour
{
    public MainMünzeSpawnen spawner;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null)
            {
                spawner.currentCoins--;
            }

            Destroy(gameObject);
        }
    }
}
