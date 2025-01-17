using UnityEngine;

namespace Hero
{
    public abstract class Item : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        public Sprite itemIcon;
        public bool isStackable;
        public int quantity = 1;
        public abstract void Use(Player player);
    }


}