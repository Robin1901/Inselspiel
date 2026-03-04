using UnityEngine;
using System.Collections;

public class CopyMünzeEinsammeln : MonoBehaviour
{
    public MainMünzeSpawnen spawner;
    public AudioClip coinCollect;
    public int coinWorth = 1;

    private bool isCollected = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;

            if (spawner != null)
            {
                spawner.currentCoins--;
            }

            CollectCoin();
        }
    }

    public void CollectCoin()
    {
        if (coinCollect != null)
        {
            AudioSource.PlayClipAtPoint(coinCollect, transform.position, 0.28f);
        }

        GetComponent<Collider>().enabled = false;
        GameManager.Instance.AddMoney(coinWorth);
        StartCoroutine(AnimatePickup());
    }

    private IEnumerator AnimatePickup()
    {
        float duration = 0.15f;
        float elapsed = 0f;

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + Vector3.up * 2.0f;


        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float percent = elapsed / duration;

            transform.position = Vector3.Lerp(startPos, endPos, percent);

            yield return null;
        }

        Destroy(gameObject);
    }
}