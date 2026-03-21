using System.Collections.Generic;
using UnityEngine;

public class BackpacksMenu : MonoBehaviour
{
    [SerializeField] DataBaseBackpackItem dataBaseBackpackItems;
    [SerializeField] GameObject backpackItemPrefab;
    [SerializeField] Transform content;
    private HashSet<int> idsBackpack = new HashSet<int>();
    private int equipedBackpack = -1;
    private bool firstSpawn = true;
    private List<ShopItemUI> shopItemUIs = new List<ShopItemUI>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (firstSpawn)
        {
            FillMenuWithBackpacks();
            firstSpawn = false;
        }

    }
    private void OnEnable()
    {
        if (!firstSpawn)
        {
            RefreshBackpacksPage();
        }
    }
    private void FillMenuWithBackpacks()
    {
        foreach (BackpackItem backpack in dataBaseBackpackItems.backpacks)
        {
            GameObject obj = Instantiate(backpackItemPrefab, content);
            ShopItemUI shop = obj.GetComponent<ShopItemUI>();
            shop.SetDataToBuy(backpack.ID, backpack.capacity, backpack.moneyMultiplier, backpack.image, backpack.price);
            shopItemUIs.Add(shop);
        }
    }
    public void RefreshBackpacksPage()
    {
        for (int i = 0; i < shopItemUIs.Count; i++)
        {
            if (i == equipedBackpack)
            {
                shopItemUIs[i].SetDataEquiped();
            }
            else if (idsBackpack.Contains(i))
            {
                shopItemUIs[i].SetDataEquip();
                shopItemUIs[i].SetListenerToEquip(i, this);
            }
        }
    }
    public void AddBackpack(int id)
    {
        idsBackpack.Add(id);
    }
    public void ChangeBacpackIDEquiped(int id)
    {
        equipedBackpack = id;
        SnowManager snowManager = GameObject.Find("SnowManager").GetComponent<SnowManager>();
        MoneyManager moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        if (snowManager != null && moneyManager != null)
        {
            moneyManager.shovelMultiplier = dataBaseBackpackItems.backpacks[id].moneyMultiplier;
            snowManager.ChaneMaxNumberOfSnow(dataBaseBackpackItems.backpacks[id].capacity);
        }
        shopItemUIs[id].SetDataEquiped();
        RefreshBackpacksPage();
    }
}
