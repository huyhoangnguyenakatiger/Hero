using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

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

    public List<Item> items = new List<Item>();

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        Debug.Log($"Đã thêm item: {newItem.itemName}");
    }
    public void RemoveItem(Item itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
            Debug.Log($"Đã xóa item: {itemToRemove.itemName}");
        }
        else
        {
            Debug.LogWarning($"Item {itemToRemove.itemName} không tồn tại trong Inventory.");
        }
    }

    public void DisplayInventory()
    {
        Debug.Log("Inventory hiện tại:");
        foreach (var item in items)
        {
            Debug.Log(item.itemName);
        }
    }
}
