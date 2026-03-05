using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinWorthUpgradeButton : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI buttonText;

    void Awake()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        if (button == null)
            Debug.LogError("CoinWorthUpgradeButton: Button-Komponente fehlt!");

        if (buttonText == null)
            Debug.LogError("CoinWorthUpgradeButton: TextMeshProUGUI fehlt!");

        button.onClick.AddListener(OnUpgradeButtonClicked);
    }

    void Update()
    {
        if (GameManager.Instance == null || buttonText == null) return;

        float price = GameManager.Instance.GetCoinWorthUpgradePrice();
        buttonText.text = $"Cost: {price}";
    }

    void OnUpgradeButtonClicked()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.UpgradeCoinWorth();
    }
}