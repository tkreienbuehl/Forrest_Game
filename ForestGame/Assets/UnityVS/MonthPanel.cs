using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthPanel : MonoBehaviour
{
    public Text monthText;
    public Text yearText;

    public void SetYearValues(int yearCounter)
    {
        int remainingYears = 4 - yearCounter;
        yearText.text = "Years until election: " + remainingYears;
    }

    public void SetMonthValues(int monthCounter)
    {
        switch (monthCounter)
        {
            case 1:
                monthText.text = "January";
                break;
            case 2:
                monthText.text = "February";
                break;
            case 3:
                monthText.text = "March";
                break;
            case 4:
                monthText.text = "April";
                break;
            case 5:
                monthText.text = "May";
                break;
            case 6:
                monthText.text = "June";
                break;
            case 7:
                monthText.text = "Juli";
                break;
            case 8:
                monthText.text = "August";
                break;
            case 9:
                monthText.text = "September";
                break;
            case 10:
                monthText.text = "October";
                break;
            case 11:
                monthText.text = "November";
                break;
            case 12:
                monthText.text = "December";
                break;
        }

    }
}
