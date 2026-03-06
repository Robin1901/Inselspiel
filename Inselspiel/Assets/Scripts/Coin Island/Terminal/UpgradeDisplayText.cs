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

        float currentSpawn = CoinIslandManager.Instance.GetRoundedSpawnSpeed();
        float nextSpawn = CoinIslandManager.Instance.GetNextRoundedSpawnSpeed();

        textMesh.text = $"Coin Worth\n{currentWorth.ToString("0.0")}  →  {nextWorth.ToString("0.0")}\n\nSpawn Speed\n{currentSpawn.ToString("0.0")}  →  {nextSpawn.ToString("0.0")}";
    }
}