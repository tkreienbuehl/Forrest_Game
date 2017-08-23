using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandler : MonoBehaviour
{

    public Text moneyText;
    public Text yearlyCostText;

    private float money;
    private float yearlyCost;

    void Start()
    {
        money = 20000;
        yearlyCost = 10000;
        moneyText.text = "Money: " + money;
        yearlyCostText.text = "Yearly cost: " + yearlyCost;
    }

    public void ChangeMoneyAmount(float change)
    {
        money += change;
        moneyText.text = "Money: " + money;
    }

    public void ChangeYearlyCostAmount(float change)
    {
        yearlyCost += change;
        yearlyCostText.text = "Yearly cost: " + yearlyCost;
    }

    public float getYearlyCosts() {
        return yearlyCost;
    }
}
