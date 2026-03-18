using UnityEngine;
[CreateAssetMenu(fileName = "Backpack", menuName = "Shop/Backpacks/Backpack")]
public class BackpackItem : ScriptableObject
{
    public int ID;
    public float price;
    public Sprite image;
    public int capacity;
    public float moneyMultiplier;
}
