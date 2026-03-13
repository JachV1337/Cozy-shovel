using System.Collections.Generic;
using UnityEngine;

public class ShovelsMenu : MonoBehaviour
{
    [SerializeField] DataBaseShovelsItems dataBaseShovelsItems;
    [SerializeField] GameObject shovelItemPrefab;
    [SerializeField] Transform content;
    private HashSet<int> idsShovel = new HashSet<int>();
    private int equipedShovel = -1;
    private bool firstSpawn = true;
    private List<ShopItemUI> shopItemUIs = new List<ShopItemUI>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (firstSpawn)
        {
            FillMenuWithShovels();
            firstSpawn = false;
        }

    }
    private void OnEnable()
    {
        if (!firstSpawn)
        {
            RefreshShovelsPage();
        }
    }
    private void FillMenuWithShovels()
    {
        foreach (ShovelsItems shovel in dataBaseShovelsItems.shovelsItems)
        {
            GameObject obj = Instantiate(shovelItemPrefab, content);
            ShopItemUI shop = obj.GetComponent<ShopItemUI>();
            shop.SetDataToBuy(shovel.ID, shovel.timeToDestroy, shovel.moneyMultiplier, shovel.image, shovel.price);
            shopItemUIs.Add(shop);
        }
    }
    public void RefreshShovelsPage()
    {
        for (int i = 0; i < shopItemUIs.Count; i++)
        {
            if (i == equipedShovel)
            {
                shopItemUIs[i].SetDataEquiped();
            }
            else if (idsShovel.Contains(i))
            {
                shopItemUIs[i].SetDataEquip();
                shopItemUIs[i].SetListenerToEquip(i,this);
            }
        }
    }
    public void AddShovel(int id)
    {
        idsShovel.Add(id);
    }
    public void ChangeShovelIDEquiped(int id)
    {
        equipedShovel = id;
        TakeSnow takeSnow = GameObject.FindWithTag("Player").GetComponent<TakeSnow>();
        MoneyManager moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        if (takeSnow != null && moneyManager != null)
        {
            moneyManager.shovelMultiplier = dataBaseShovelsItems.shovelsItems[id].moneyMultiplier;
            takeSnow.timeToDestroySnow = dataBaseShovelsItems.shovelsItems[id].timeToDestroy;
        }
        shopItemUIs[id].SetDataEquiped();
        RefreshShovelsPage();
    }

}
