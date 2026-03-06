using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnspeedUpgradeButton : MonoBehaviour
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

        float currentSpeed = CoinIslandManager.Instance.coinSpawnspeed;

        if (currentSpeed <= 0.6f)
        {
            buttonText.text = "MAXED";

            button.interactable = false;
        }
        else
        {
            float price = CoinIslandManager.Instance.GetSpawnspeedUpgradePrice();
            buttonText.text = $"UPGRADE\n<sprite name=\"CoinIcon_0\"> {price}";

            button.interactable = true;
        }
    }

    void OnUpgradeButtonClicked()
    {
        if (CoinIslandManager.Instance == null) return;

        CoinIslandManager.Instance.UpgradeSpawnspeed();
    }
}