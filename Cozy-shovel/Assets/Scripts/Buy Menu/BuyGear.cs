using UnityEngine;

public class BuyGear : MonoBehaviour
{
    [SerializeField] MoneyManager money;
    public void BuyShovel(int id, float price)
    {
        if(price <= money.currentMoney)
        {
            money.ChangeMoney(-price);
            ShovelsMenu shovelsMenu = GameObject.Find("ShovelsMenu").GetComponent<ShovelsMenu>();
            shovelsMenu.AddShovel(id);
        }
    }
}
