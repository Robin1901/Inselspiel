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
        if (GameManager.Instance == null || textMesh == null) return;

        float currentWorth = GameManager.Instance.GetRoundedCoinWorth();
        float nextWorth = GameManager.Instance.GetNextRoundedCoinWorth();

        float currentSpawn = GameManager.Instance.GetRoundedSpawnSpeed();
        float nextSpawn = GameManager.Instance.GetNextRoundedSpawnSpeed();

        textMesh.text = $"Coin Worth\n{currentWorth.ToString("0.0")}  -  {nextWorth.ToString("0.0")}\n\nSpawn Speed\n{currentSpawn.ToString("0.0")}  -  {nextSpawn.ToString("0.0")}";
    }
}