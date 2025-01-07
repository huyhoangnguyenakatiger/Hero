using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Hero/Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int maxStack = 1;
    public bool isStackable;
}
