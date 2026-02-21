using UnityEngine;

public class Snow : MonoBehaviour
{
    [SerializeField] SnowManager snowManager;
    public int snowToGive = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        snowManager = GameObject.Find("SnowManager").GetComponent<SnowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroySnow()
    {
        snowManager.UpdateNumberOfSnow(snowToGive);
        Destroy(gameObject);
    }
}
