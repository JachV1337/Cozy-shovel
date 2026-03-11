using System.Collections.Generic;
using UnityEngine;

public class ShovelsMenu : MonoBehaviour
{
    [SerializeField] DataBaseShovelsItems dataBaseShovelsItems;
    [SerializeField] GameObject shovelItemPrefab;
    [SerializeField] Transform content;
    private HashSet<int> idsShovel = new HashSet<int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FillMenuWithShovels();
    }
    private void FillMenuWithShovels()
    {
        foreach (ShovelsItems shovel in dataBaseShovelsItems.shovelsItems)
        {
            GameObject obj = Instantiate(shovelItemPrefab, content);
            ShopItemUI shop = obj.GetComponent<ShopItemUI>();
            if (idsShovel.Contains(shovel.ID))
            {
                shop.SetDataBought(shovel.timeToDestroy, shovel.moneyMultiplier, shovel.image);
            }
            else
            {
                shop.SetDataToBuy(shovel.ID, shovel.timeToDestroy, shovel.moneyMultiplier, shovel.image, shovel.price);
            }
        }
    }
    public void AddShovel(int id)
    {
        idsShovel.Add(id);
    }
  
}
