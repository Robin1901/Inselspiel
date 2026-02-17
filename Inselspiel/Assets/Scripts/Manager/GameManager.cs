using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int characterMoney = 0;

    private void Awake()
    {
        Instance = this;
        Debug.Log("Money: " + characterMoney);
    }

    public void AddMoney(int amount)
    {
        characterMoney += amount;
        Debug.Log("Money: " + characterMoney);
    }
}
