using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private Countable MoneyText;

    public int Money = 0;

    [ContextMenu("add 500")]
    public void Add500()
    {
        AddMoney(500);
    }

    public void AddMoney(int addedValue)
    {
        Money += addedValue;
        MoneyText.SetNumber(Money);
    }
}