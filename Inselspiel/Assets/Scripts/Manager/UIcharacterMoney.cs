using UnityEngine;
using TMPro;

public class UIcharacterMoney : MonoBehaviour
{
    private CoinIslandManager coinIslandManager;
    public TextMeshProUGUI moneyText;

    void Start()
    {
        GameObject managerObj = GameObject.Find("Coin Island Manager");
        if (managerObj != null)
        {
            coinIslandManager = managerObj.GetComponent<CoinIslandManager>();
        }
    }

    void Update()
    {
        moneyText.text = coinIslandManager.characterMoney.ToString("F0");
    }
}