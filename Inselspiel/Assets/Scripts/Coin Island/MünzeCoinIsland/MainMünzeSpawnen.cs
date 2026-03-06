using UnityEngine;

public class MainMünzeSpawnen : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private float timer = 0f;
    private float dropInterval = 3f;

    public int maxCoins = 30;
    [HideInInspector] public int currentCoins = 0;

    void Start()
    {
        if (CoinIslandManager.Instance != null)
            dropInterval = CoinIslandManager.Instance.coinSpawnSpeed;
    }

    void Update()
    {
        if (CoinIslandManager.Instance != null)
            dropInterval = CoinIslandManager.Instance.coinSpawnSpeed;

        timer += Time.deltaTime;
        if (timer >= dropInterval)
        {
            timer = 0f;
            if (currentCoins < maxCoins)
            {
                SpawnCoin();
            }
        }
    }

    private void SpawnCoin()
    {
        if (coinPrefab == null)
        {
            Debug.LogWarning("Coin Prefab ist nicht gesetzt!");
            return;
        }

        Vector3 spawnPos = transform.position;
        GameObject newCoin = Instantiate(coinPrefab, spawnPos, transform.rotation);
        currentCoins++;

        CopyMünzeEinsammeln coinScript = newCoin.GetComponent<CopyMünzeEinsammeln>();
        if (coinScript != null)
        {
            coinScript.spawner = this;
        }
        else
        {
            Debug.LogWarning("Prefab hat kein CopyMünzeEinsammeln Script");
        }
    }

    public void NotifyCoinDestroyed()
    {
        currentCoins = Mathf.Max(0, currentCoins - 1);
    }
}