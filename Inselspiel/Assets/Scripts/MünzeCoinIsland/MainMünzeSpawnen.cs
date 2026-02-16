using UnityEngine;

public class MainMünzeSpawnen : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private float minDropInterval = 3f;
    private float maxDropInterval = 5f;

    private float timer;
    private float nextDropTime;

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
            SpawnCoin();

            nextDropTime = Random.Range(minDropInterval, maxDropInterval);
        }
    }

    private void SpawnCoin()
    {
        Vector3 spawnPos = transform.position;
        Instantiate(coinPrefab, spawnPos, transform.rotation);
    }
}
