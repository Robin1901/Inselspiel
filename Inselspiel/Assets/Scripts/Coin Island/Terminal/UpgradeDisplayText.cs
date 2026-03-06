using UnityEngine;
using TMPro;

public class UpgradeDisplayText : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        if (textMesh == null)
        {
            Debug.LogError("Kein TextMeshProUGUI auf diesem GameObject gefunden!");
        }
    }

    void Update()
    {
        if (CoinIslandManager.Instance == null || textMesh == null) return;

        float currentWorth = CoinIslandManager.Instance.GetRoundedCoinWorth();
        float nextWorth = CoinIslandManager.Instance.GetNextRoundedCoinWorth();

        float currentSpawn = CoinIslandManager.Instance.GetRoundedSpawnspeed();
        float nextSpawn = CoinIslandManager.Instance.GetNextRoundedSpawnspeed();

        string spawnDisplayText;
        if (currentSpawn <= 0.5f)
        {
            spawnDisplayText = "Maxed: 0.5s";

        }
        else
        {
            spawnDisplayText = $"{currentSpawn.ToString("0.0")}s → {nextSpawn.ToString("0.0")}s";
        }

        textMesh.text = $"Coin Worth\n<sprite name=\"CoinIcon_0\">{currentWorth.ToString()}  →   <sprite name=\"CoinIcon_0\">{nextWorth.ToString()}\n\n" +
                        $"Spawn Speed\n{spawnDisplayText}";
    }
}