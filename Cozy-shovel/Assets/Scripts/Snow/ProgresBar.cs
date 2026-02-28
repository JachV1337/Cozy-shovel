using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ProgresBar : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Slider progresSlider;

    //private float maxValue = 250f;
    private float regenAmount = 5f;   // ile dodaje
    private float regenDelay = 0.05f;    // co ile sekund

    private TakeSnow takeSnow;
    private Coroutine progresBar;

    void Start()
    {
        takeSnow = GameObject.FindWithTag("Player").GetComponent<TakeSnow>();
        progresSlider.minValue = 0;
    }
    public void StartToTakeSnow(float maxValueTimer)
    {
        maxValueTimer *= 100;
        progresSlider.maxValue = maxValueTimer;
        canvas.SetActive(true);
        progresBar = StartCoroutine(ProgresBarTimer(maxValueTimer));
    }
    private void CancelTakingSnow()
    {
        canvas.SetActive(false);
        if (progresBar != null)
        {
            StopCoroutine(progresBar);
        }
        progresSlider.value = 0;
    }
    private void Update()
    {
      if (canvas.activeSelf)
      {
            if (!takeSnow.isTakingSnow)
            {
                CancelTakingSnow();
            }
      }
        
    }

    IEnumerator ProgresBarTimer(float maxValue)
    {
        while (progresSlider.value < maxValue)
        {
            yield return new WaitForSeconds(regenDelay);

            progresSlider.value += regenAmount;
            progresSlider.value = Mathf.Clamp(progresSlider.value, 0, maxValue);
        }
    }
}
