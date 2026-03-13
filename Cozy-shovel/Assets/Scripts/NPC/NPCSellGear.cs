using UnityEngine;

public class NPCSellGear : MonoBehaviour
{
    [SerializeField] GameObject GearSellMenuButton;
    [SerializeField] GameObject GearSellMenu;
    private bool playerOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GearSellMenuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GearSellMenuButton.SetActive(true);
            playerOn = true;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GearSellMenuButton.SetActive(false);
        GearSellMenu.SetActive(false);
        playerOn = false;
    }
    public void ShowBuyMenu()
    {
        GearSellMenu.SetActive(true);
        GearSellMenuButton.SetActive(false);
    }
    public void CloseMenu()
    {
        GearSellMenu.SetActive(false);
        if (playerOn)
        {
            GearSellMenuButton.SetActive(false);
        }

    }
}
