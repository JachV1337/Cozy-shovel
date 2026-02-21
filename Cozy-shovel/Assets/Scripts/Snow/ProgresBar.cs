using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ProgresBar : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Slider progresSlider;

    private float maxValue = 250f;
    private float regenAmount = 10f;   // ile dodaje
    private float regenDelay = 0.1f;    // co ile sekund

    private TakeSnow takeSnow;
    private Coroutine regen;

    void Start()
    {
        takeSnow = GameObject.FindWithTag("Player").GetComponent<TakeSnow>();
        progresSlider.minValue = 0;
        progresSlider.maxValue = maxValue;

        
    }
    public void StartToTakeSnow()
    {
        canvas.SetActive(true);
        regen = StartCoroutine(Regenerate());
    }
    private void CancelTakingSnow()
    {
        canvas.SetActive(false);
        if (regen != null)
        {
            StopCoroutine(regen);
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

    IEnumerator Regenerate()
    {
        while (progresSlider.value < maxValue)
        {
            yield return new WaitForSeconds(regenDelay);

            progresSlider.value += regenAmount;
            progresSlider.value = Mathf.Clamp(progresSlider.value, 0, maxValue);
        }
    }
}
