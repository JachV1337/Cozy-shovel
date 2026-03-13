using UnityEngine;
using UnityEngine.UI;

public class BuyGear : MonoBehaviour
{
    [SerializeField] MoneyManager money;
    public void BuyShovel(int id, float price,Button button, ShopItemUI shopItemUI)
    {
        if(price <= money.currentMoney)
        {
            money.ChangeMoney(-price);
            ShovelsMenu shovelsMenu = GameObject.Find("ShovelsMenu").GetComponent<ShovelsMenu>();
            shovelsMenu.ChangeShovelIDEquiped(id);
            button.onClick.RemoveAllListeners();
            shovelsMenu.AddShovel(id);
            shovelsMenu.RefreshShovelsPage();
        }
    }
}
