using UnityEngine;
using UnityEngine.UI;
using TMPro; // jeśli używasz TextMeshPro

public class ShopItemUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text destroyTimeText;
    public TextMeshProUGUI moneyMultiplierText;
    public TMP_Text priceText;

    public void SetData(float destroyTime,float moneyMultiplier, Sprite img, float price)
    {
        icon.sprite = img;
        destroyTimeText.text = "Take snow: " + destroyTime.ToString();
        moneyMultiplierText.text = "Money multiplier: " + moneyMultiplier.ToString();
        priceText.text = price + "$";
    }
}

