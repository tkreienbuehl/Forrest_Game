using UnityEngine;
using UnityEngine.UI;

public class ResultHandler : MonoBehaviour
{
    public Image environmental;
    public Image industry;
    public Image tourist;

    public void CalculateIndustrialInfluences(short influences)
    {
        industry.fillAmount = industry.fillAmount + influences / 100f;
    }

    public void CalculateEnvironmentalInfluences(short influences)
    {
        environmental.fillAmount = environmental.fillAmount + influences / 100f;
    }

    public void CalculateTouristInfluences(short influences)
    {
        tourist.fillAmount = tourist.fillAmount + influences / 100f;
    }

}