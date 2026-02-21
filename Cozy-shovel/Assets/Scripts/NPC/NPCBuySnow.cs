using UnityEngine;

public class NPCBuySnow : MonoBehaviour, INPCInteractable
{
    [SerializeField] GameObject SnowSellMenu;
    bool isOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InteractWithNPC()
    {
        if (isOpen)
        {
            SnowSellMenu.SetActive(false);
        }
        else if (!isOpen)
        {
            SnowSellMenu.SetActive(true);
        }
    }
}
