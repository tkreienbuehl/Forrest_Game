using UnityEngine;
using System.Collections;

public class MainYearTrigger : MonoBehaviour {

    public MoneyHandler moneyHandler;
    private float deltaYearTime;
    private float deltaMonthTime;
    private const float timeForAYear = 120.0f;
    private const float timeForAMonth = timeForAYear / 12.0f;

    // Use this for initialization
    void Start() {
        deltaMonthTime = 0.0f;
        deltaYearTime = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        checkMonthHasPast();
        if (checkYearHasPast()) {
            moneyHandler.ChangeMoneyAmount(moneyHandler.getYearlyCosts());
        }
    }

    private bool checkYearHasPast() {
        if (deltaYearTime > timeForAYear) {
            deltaYearTime = 0.0f;
            return true;
        }
        return false;
    }

    private bool checkMonthHasPast() {
        if (deltaMonthTime > timeForAMonth) {
            deltaMonthTime = 0.0f;
            return true;
        }
        return false;
    }
}
