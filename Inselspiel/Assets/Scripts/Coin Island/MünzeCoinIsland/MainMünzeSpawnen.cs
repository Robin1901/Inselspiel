using UnityEngine;

public class MainMünzeSpawnen : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private float minDropInterval = 3f;
    private float maxDropInterval = 5f;
    private float timer;
    private float nextDropTime;

    public int maxCoins = 30;
    [HideInInspector] public int currentCoins = 0;

    void Start()
    {
        nextDropTime = Random.Range(minDropInterval, maxDropInterval);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextDropTime)
        {
            timer = 0f;
            if (currentCoins < maxCoins)
            {
                SpawnCoin();
            }
            nextDropTime = Random.Range(minDropInterval, maxDropInterval);
        }
    }

    private void SpawnCoin()
    {
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
}
