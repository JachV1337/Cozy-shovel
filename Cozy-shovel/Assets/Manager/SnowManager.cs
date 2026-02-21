using TMPro;
using UnityEngine;

public class SnowManager : MonoBehaviour
{
    public int currentNumberOfSnow;
    private int maxNumberOfSnow = 5;
    [SerializeField] TextMeshProUGUI numberOfSnowText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateNumberText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateNumberOfSnow(int snow)
    {
        if (currentNumberOfSnow < maxNumberOfSnow)
        {
            currentNumberOfSnow += snow;
        }
        UpdateNumberText();
    }
    public void UpdateNumberText()
    {
        numberOfSnowText.text = currentNumberOfSnow + " / " + maxNumberOfSnow;
    }
}
