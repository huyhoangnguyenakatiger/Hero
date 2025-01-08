using UnityEngine;
using System.Collections.Generic;

namespace Hero
{
    public class QuickSlotManager : MonoBehaviour
    {

        public List<QuickSlot> quickSlots;

        private void Update()
        {
            HandleQuickSlotUsage();
        }

        private void HandleQuickSlotUsage()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) UseQuickSlot(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) UseQuickSlot(1);
        }

        public void UseQuickSlot(int slotIndex)
        {
            if (slotIndex >= 0 && slotIndex < quickSlots.Count)
            {
                QuickSlot slot = quickSlots[slotIndex];
                if (slot.item != null && slot.item.quantity > 0)
                {
                    Player player = FindFirstObjectByType<Player>();
                    if (player != null)
                    {
                        slot.item.Use(player);
                        slot.item.quantity--;

                        Debug.Log($"Đã sử dụng {slot.item.itemName} từ Quick Slot {slotIndex + 1}.");
                        if (slot.item.quantity <= 0)
                        {
                            Debug.Log($"{slot.item.itemName} đã hết trong Quick Slot {slotIndex + 1}.");
                        }
                    }
                    else
                    {
                        Debug.Log("Không tìm thấy Player để sử dụng item.");
                    }
                }
                else
                {
                    Debug.Log($"Quick Slot {slotIndex + 1} trống hoặc item đã hết.");
                }
            }
        }
    }
}
