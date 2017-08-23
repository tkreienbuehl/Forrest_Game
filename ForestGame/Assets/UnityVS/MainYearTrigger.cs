using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainYearTrigger : MonoBehaviour {

    public MoneyHandler moneyHandler;
    public MonthPanel monthPanel;
    private DecisionPanelContent content;
    private float deltaYearTime;
    private float deltaMonthTime;
    private const float timeForAYear = 120.0f;
    private const float timeForAMonth = timeForAYear / 12.0f;
    private short yearCounter;
    private int monthCounter;

    // Use this for initialization
    void Start() {
        deltaMonthTime = 0.0f;
        deltaYearTime = 0.0f;
        yearCounter = 0;
        monthCounter = 1;
        content = GameObject.Find("PanelCanvas").gameObject.GetComponent<DecisionPanelContent>();
    }

    // Update is called once per frame
    void Update() {
        deltaMonthTime += Time.deltaTime;
        deltaYearTime += Time.deltaTime;
        checkMonthHasPast();
        if (checkYearHasPast()) {
            yearCounter++;
            monthPanel.SetYearValues(yearCounter);
            if (yearCounter == 3) {
                //TODO start election campain
            }
            if (yearCounter == 4) {
                // triggers the elections after a certain amount of time

                bool isReelected = content.resultHandler.isReelected();

                // triggers reelected UI based on influence
                if (isReelected) {
                    SceneManager.LoadScene(9);
                }
                else {
                    SceneManager.LoadScene(10);
                }
                yearCounter = 0;
            }
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
            monthCounter++;
            if (monthCounter > 12)
            {
                monthCounter = 1;
            }
            monthPanel.SetMonthValues(monthCounter);
            return true;
        }
        return false;
    }
}
