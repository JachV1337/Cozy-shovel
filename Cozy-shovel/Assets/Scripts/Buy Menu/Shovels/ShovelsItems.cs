using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Shovel", menuName = "Shop/Shovels/Shovel")]
public class ShovelsItems : ScriptableObject
{
    public int ID;
    public float price;
    public Image image;
    public float timeToDestroy;
    public float moneyMultiplier;
}
