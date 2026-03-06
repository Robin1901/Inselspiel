using UnityEngine;

public class CoinIslandManager : MonoBehaviour
{
    public static CoinIslandManager Instance;

    public float characterMoney = 0f;

    public float coinWorth = 1.0f;
    public float coinWorthMultiplier = 1.2f;
    public float coinSpawnSpeed = 3.5f;
    public float coinSpawnMultiplier = 0.925f;

    //------------- Prices

    public float coinWorthUpgradePrice = 5f;
    public float coinWorthPriceMultiplier = 1.5f;

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


    //------------------------------------


    public void AddMoney(float value)
    {
        characterMoney += value;
    }

    //-------------------------------------

    public void UpgradeCoinWorth()
    {
        if (characterMoney >= coinWorthUpgradePrice)
        {
            characterMoney -= coinWorthUpgradePrice;
            coinWorth *= coinWorthMultiplier;
            coinWorthUpgradePrice *= coinWorthPriceMultiplier;
        }
    }

    //---------------------------------------------

    public float GetRoundedCoinWorth()
    {
        return Mathf.Round(coinWorth * 10f) / 10f;
    }

    public float GetNextRoundedCoinWorth()
    {
        return Mathf.Round(coinWorth * coinWorthMultiplier * 10f) / 10f;
    }

    //-------------------------------------

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

    //-------------------------------------  
    public float GetCoinWorthUpgradePrice()
    {
        return Mathf.Round(coinWorthUpgradePrice * 10f) / 10f;
    }
}