using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MagnetRadiusUpgradeButton : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI buttonText;

    void Awake()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        button.onClick.AddListener(OnUpgradeButtonClicked);
    }

    void Update()
    {
        if (CoinIslandManager.Instance == null || buttonText == null) return;

        float price = CoinIslandManager.Instance.GetMagnetRadiusUpgradePrice();

        buttonText.text = $"UPGRADE\n<sprite name=\"CoinIcon_0\">{price}";
    }

    void OnUpgradeButtonClicked()
    {
        if (CoinIslandManager.Instance == null) return;

        CoinIslandManager.Instance.UpgradeMagnetRadius();
    }
}