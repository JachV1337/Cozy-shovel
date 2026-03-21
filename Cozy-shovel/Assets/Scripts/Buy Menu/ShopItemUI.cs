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
        button.onClick.AddListener(() => buyGear.BuyShovel(id,price,button, this));
    }
    public void SetDataEquip()
    {
        priceText.text = "Equip";
    }
    public void SetDataEquiped()
    {
        priceText.text = "Equiped";
    }
    public void SetListenerToEquip<T>(int id, T menu)
    {
        if (menu is ShovelsMenu shovelMenu)
        {
            button.onClick.AddListener(() => shovelMenu.ChangeShovelIDEquiped(id));
        }
    }
}

