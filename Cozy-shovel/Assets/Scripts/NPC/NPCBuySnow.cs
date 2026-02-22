using UnityEngine;

public class NPCBuySnow : MonoBehaviour
{
    [SerializeField] GameObject SnowSellMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SnowSellMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SnowSellMenu.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SnowSellMenu.SetActive(false);
    }
}
