using UnityEngine;
using UnityEngine.UI;

public class BuyGear : MonoBehaviour
{
    [SerializeField] MoneyManager money;
    public void BuyShovel(int id, float price,Button button)
    {
        if(price <= money.currentMoney)
        {
            money.ChangeMoney(-price);
            ShovelsMenu shovelsMenu = GameObject.Find("ShovelsMenu").GetComponent<ShovelsMenu>();
            button.onClick.RemoveAllListeners();
            shovelsMenu.AddShovel(id);
        }
    }
}
