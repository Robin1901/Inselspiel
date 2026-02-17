using UnityEngine;

public class CopyMünzeEinsammeln : MonoBehaviour
{
    public MainMünzeSpawnen spawner;
    public AudioClip coinCollect;

    void Start ()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null)
            {
                spawner.currentCoins--;
            }

            CollectCoin();
        }
    }


    public void CollectCoin()
    {
        AudioSource.PlayClipAtPoint(coinCollect, transform.position, 0.28f); //0.3 war bisschen zu laut HAHAH
        Destroy(gameObject);
    }
}
