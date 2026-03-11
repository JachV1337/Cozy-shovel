using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    public float currentMoney { get; private set; } = 0;
    private float multiplier = 1.5f;
    private SnowManager snowManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateText();
        snowManager = GameObject.Find("SnowManager").GetComponent<SnowManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeMoneyFromSnow()
    {
        float amount = snowManager.currentNumberOfSnow;
        amount *= multiplier;
        amount = (float)Math.Round(amount,2);
        currentMoney += amount;
        snowManager.UpdateNumberOfSnow(-snowManager.currentNumberOfSnow);
        UpdateText();
    }
    public void ChangeMoney(float amount)
    {
        currentMoney += amount;
        UpdateText();
    }
    void UpdateText()
    {
        moneyText.text = currentMoney.ToString();
    }
}
