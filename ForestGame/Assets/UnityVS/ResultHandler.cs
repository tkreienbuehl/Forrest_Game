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
        // TODO calculate the amount of influences
        environmental.fillAmount = 1f;
        industry.fillAmount = 0.2f;
        tourist.fillAmount = 0.7f;
    }

}