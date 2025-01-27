using UnityEngine;
using System.Collections.Generic;
using System;

namespace Hero
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;

        public List<Item> items = new List<Item>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void AddItem(Item newItem)
        {
            if (newItem.isStackable)
            {
                Item existingItem = items.Find(i => i.itemName == newItem.itemName);
                if (existingItem != null)
                {
                    existingItem.quantity++;
                    Debug.Log($"Đã tăng số lượng: {existingItem.itemName} ({existingItem.quantity})");
                    return;
                }
            }
            items.Add(newItem);
            newItem.quantity++;
            Debug.Log($"Đã thêm item mới: {newItem.itemName} (x{newItem.quantity})");
        }

        public void UseItem(Item item, Player player)
        {
            if (item != null)
            {
                item.Use(player);
                if (item.isStackable)
                {
                    item.quantity--;
                    if (item.quantity <= 0)
                    {
                        items.Remove(item);
                        Debug.Log($"{item.itemName} đã hết và bị xóa khỏi Inventory.");
                    }
                }
                else
                {
                    items.Remove(item);
                    Debug.Log($"{item.itemName} đã bị xóa khỏi Inventory sau khi sử dụng.");
                }
            }
        }

        public int GetItemQuantity(Item item)
        {
            if (item == null) return 0;

            Item existingItem = items.Find(i => i.itemName == item.itemName);
            return existingItem != null ? existingItem.quantity : 0;
        }

    }
}
