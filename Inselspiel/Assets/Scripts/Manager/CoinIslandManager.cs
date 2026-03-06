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

    [Header("Magnet Radius Settings")]
    public float magnetRadius = 1.75f;
    public float magnetRadiusUpgradePrice = 100f;
    public float magnetRadiusUpgradePriceMultiplier = 1.1f;

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

    public void UpgradeMagnetRadius()
    {
        if (characterMoney >= magnetRadiusUpgradePrice && magnetRadius < 7.5f)
        {
            characterMoney -= magnetRadiusUpgradePrice;
            magnetRadius += 0.25f;

            if (magnetRadius > 7.5f) magnetRadius = 7.5f;

            magnetRadiusUpgradePrice *= magnetRadiusUpgradePriceMultiplier;
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
    public int GetCoinWorthUpgradePrice()
    {
        return Mathf.FloorToInt(coinWorthUpgradePrice);
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
    public int GetSpawnspeedUpgradePrice()
    {
        return Mathf.FloorToInt(coinSpawnspeedUpgradePrice);
    }






    public float GetRoundedMagnetRadius()
    {
        return magnetRadius;
    }

    public float GetNextRoundedMagnetRadius()
    {
        float nextValue = magnetRadius + 0.25f;
        if (nextValue > 7.5f) nextValue = 7.5f;
        return nextValue;
    }

    public int GetMagnetRadiusUpgradePrice()
    {
        return Mathf.FloorToInt(magnetRadiusUpgradePrice);
    }
}