using UnityEngine;

public class CoinIslandManager : MonoBehaviour
{
    public static CoinIslandManager Instance;

    public float characterMoney = 0f;

    [Header("Spawn Speed Settings")]
    public float coinSpawnspeed = 3.5f;
    public float coinSpawnspeedUpgradePrice = 50f;
    public float coinSpawnspeedUpgradePriceMultiplier = 1.18f;

    [Header("Coin Worth Settings")]
    public float coinWorth = 10f;
    public float coinWorthMultiplier = 1.1f;
    public float coinWorthUpgradePrice = 50f;
    public float coinWorthUpgradePriceMultiplier = 1.18f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public bool inputBlocked = false;

    public void SetInputBlocked(bool block)
    {
        inputBlocked = block;
        if (block)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void AddMoney(float value)
    {
        characterMoney += value;
        characterMoney = Mathf.Round(characterMoney * 100f) / 100f;
    }

    // ----------- Upgrades durchführen

    public void UpgradeCoinWorth()
    {
        if (characterMoney >= coinWorthUpgradePrice)
        {
            characterMoney -= coinWorthUpgradePrice;
            coinWorth *= coinWorthMultiplier;
            coinWorthUpgradePrice *= coinWorthUpgradePriceMultiplier;
        }
    }

    public void UpgradeSpawnspeed()
    {
        if (characterMoney >= coinSpawnspeedUpgradePrice && coinSpawnspeed > 0.5f)
        {
            characterMoney -= coinSpawnspeedUpgradePrice;
            coinSpawnspeed -= 0.1f;

            if (coinSpawnspeed < 0.5f) coinSpawnspeed = 0.5f;

            coinSpawnspeedUpgradePrice *= coinSpawnspeedUpgradePriceMultiplier;
        }
    }

    // ------------------ Werte festlegen

    public int GetRoundedCoinWorth()
    {
        return Mathf.FloorToInt(coinWorth);
    }

    public int GetNextRoundedCoinWorth()
    {
        return Mathf.FloorToInt(coinWorth * coinWorthMultiplier);
    }

    public float GetRoundedSpawnspeed()
    {
        return Mathf.Round(coinSpawnspeed * 100f) / 100f;
    }

    public float GetNextRoundedSpawnspeed()
    {
        float nextSpeed = coinSpawnspeed - 0.1f;
        if (nextSpeed < 0.5f) nextSpeed = 0.5f;
        return Mathf.Round(nextSpeed * 100f) / 100f;
    }

    public int GetCoinWorthUpgradePrice()
    {
        return Mathf.FloorToInt(coinWorthUpgradePrice);
    }

    public int GetSpawnspeedUpgradePrice()
    {
        return Mathf.FloorToInt(coinSpawnspeedUpgradePrice);
    }
}