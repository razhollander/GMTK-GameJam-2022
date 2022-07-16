using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private Countable MoneyText;

    public int Money = 0;
    
    public void AddMoney(int addedValue)
    {
        Money += addedValue;
        MoneyText.SetNumber(Money);
    }
}