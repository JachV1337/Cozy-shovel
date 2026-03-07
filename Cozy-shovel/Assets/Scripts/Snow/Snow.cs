using System.Collections;
using UnityEngine;

public class Snow : MonoBehaviour
{
    [SerializeField] SnowManager snowManager;
    [SerializeField] AudioClip breakSnowClip;
    [SerializeField] GameObject breakSnowParticle;
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
        AudioSource.PlayClipAtPoint(breakSnowClip, transform.position);
        Instantiate(breakSnowParticle,transform.position, Quaternion.identity);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
