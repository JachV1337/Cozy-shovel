using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;

public class ShopItemUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text destroyTimeText;
    public TextMeshProUGUI moneyMultiplierText;
    public TMP_Text priceText;
    public Button button;

    public void SetDataToBuy(int id, float destroyTime, float moneyMultiplier, Sprite img, float price)
    {
        icon.sprite = img;
        destroyTimeText.text = "Take snow: " + destroyTime.ToString() + "s";
        moneyMultiplierText.text = "Money multiplier: " + moneyMultiplier.ToString();
        priceText.text = price + "$";
        BuyGear buyGear = GameObject.FindWithTag("BuyGear").GetComponent<BuyGear>();
        if (buyGear == null)
        {
            return;
        }
        button.onClick.AddListener(() => buyGear.BuyShovel(id,price));
    }
    public void SetDataBought(float destroyTime, float moneyMultiplier, Sprite img)
    {
        icon.sprite = img;
        destroyTimeText.text = "Take snow: " + destroyTime.ToString();
        moneyMultiplierText.text = "Money multiplier: " + moneyMultiplier.ToString();
        priceText.text = "Bought";
    }
}

