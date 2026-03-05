using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player")]
    public float characterMoney = 0f;

    [Header("Coin Settings")]
    public float coinWorth = 1.0f;
    public float coinWorthMultiplier = 1.2f;
    public float coinSpawnSpeed = 3.5f;
    public float coinSpawnMultiplier = 0.92f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddMoney(float value)
    {
        characterMoney += value;
    }

    //-------------------------------------

    public void UpgradeCoinWorth()
    {
        coinWorth *= coinWorthMultiplier;
    }

    public float GetRoundedCoinWorth()
    {
        return Mathf.Round(coinWorth * 10f) / 10f;
    }

    public float GetNextRoundedCoinWorth()
    {
        return Mathf.Round(coinWorth * coinWorthMultiplier * 10f) / 10f;
    }

    //----------------------------------------------------------------

    public void UpgradeSpawnSpeed()
    {
        coinSpawnSpeed *= coinSpawnMultiplier;
        if (coinSpawnSpeed < 0.25f) coinSpawnSpeed = 0.25f;
    }

    public float GetRoundedSpawnSpeed()
    {
        return Mathf.Round(coinSpawnSpeed * 10f) / 10f;
    }

    public float GetNextRoundedSpawnSpeed()
    {
        return Mathf.Round(coinSpawnSpeed * coinSpawnMultiplier * 10f) / 10f;
    }
}