using UnityEngine;
using System.Collections;

public class CopyMünzeEinsammeln : MonoBehaviour
{
    public AudioClip coinCollect;
    [HideInInspector] public MainMünzeSpawnen spawner;
    private bool collected = false;

    void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        if (!other.CompareTag("Player")) return;

        collected = true;

        float value = GameManager.Instance.GetRoundedCoinWorth();
        GameManager.Instance.AddMoney(value);

        if (coinCollect != null)
            AudioSource.PlayClipAtPoint(coinCollect, transform.position, 0.28f);

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

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

        if (spawner != null)
        {
            spawner.NotifyCoinDestroyed();
        }

        Destroy(gameObject);
    }
}