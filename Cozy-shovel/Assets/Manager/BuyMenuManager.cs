using UnityEngine;

public class BuyMenuManager : MonoBehaviour
{
    [SerializeField] GameObject ShovelsMenuGO;
    [SerializeField] GameObject BackpackMenuGO;
    [SerializeField] GameObject BoostMenuGO;
   
    private void OnEnable()
    {
        ShovelMenu();
    }

    public void ShovelMenu()
    {
        ShovelsMenuGO.SetActive(true);
        BackpackMenuGO.SetActive(false);
        BoostMenuGO.SetActive(false);
    }

    public void BackpackMenu()
    {
        ShovelsMenuGO.SetActive(false);
        BackpackMenuGO.SetActive(true);
        BoostMenuGO.SetActive(false);
    }
    public void BoostMenu()
    {
        ShovelsMenuGO.SetActive(false);
        BackpackMenuGO.SetActive(false);
        BoostMenuGO.SetActive(true);
    }
}
