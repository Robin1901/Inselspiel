using UnityEngine;
using TMPro;

public class UIcharacterMoney : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshProUGUI moneyText;

    void Start()
    {
        GameObject managerObj = GameObject.Find("Game Manager");
        if (managerObj != null)
        {
            gameManager = managerObj.GetComponent<GameManager>();
        }
    }

    void Update()
    {
        moneyText.text = "Money: " + gameManager.characterMoney.ToString();
    }
}