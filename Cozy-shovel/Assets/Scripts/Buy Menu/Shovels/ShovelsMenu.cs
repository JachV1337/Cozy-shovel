using UnityEngine;

public class ShovelsMenu : MonoBehaviour
{
    [SerializeField] DataBaseShovelsItems dataBaseShovelsItems;
    [SerializeField] GameObject shovelItemPrefab;
    [SerializeField] Transform content;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (ShovelsItems shovel in dataBaseShovelsItems.shovelsItems)
        {
            GameObject obj = Instantiate(shovelItemPrefab, content);
            ShopItemUI shop = obj.GetComponent<ShopItemUI>();
            shop.SetData(shovel.timeToDestroy, shovel.moneyMultiplier,shovel.image,shovel.price);
        }
    }

  
}
