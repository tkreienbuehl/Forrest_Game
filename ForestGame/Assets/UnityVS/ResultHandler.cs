using UnityEngine;
using UnityEngine.UI;

public class ResultHandler : MonoBehaviour
{
    public Image environmental;
    public Image industry;
    public Image tourist;

    Influences influences;

    void Start() {
        
    }

    void Update()
    {
        
    }

    public void CalculateIndustrialInfluences(int influences)
    {
        industry.fillAmount += influences / 10f;
    }

    public void CalculateEnvironmentalInfluences(int influences)
    {
        environmental.fillAmount += influences / 10f;
    }

    public void CalculateTouristInfluences(int influences)
    {
        tourist.fillAmount += influences / 10f;
    }

}