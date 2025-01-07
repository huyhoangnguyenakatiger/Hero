using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class InventoryUI : MonoBehaviour
    {
        public GameObject inventoryPanel;
        public Transform content;
        public GameObject itemSlotPrefab;

        private void Start()
        {
            inventoryPanel.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryPanel.SetActive(!inventoryPanel.activeSelf);

                TogglePlayerActions(inventoryPanel.activeSelf);

                if (inventoryPanel.activeSelf)
                {
                    UpdateInventoryUI();
                }
            }
        }

        private void TogglePlayerActions(bool isInventoryOpen)
        {
            PlayerSpell playerSpell = FindFirstObjectByType<PlayerSpell>();
            if (playerSpell != null)
            {
                playerSpell.enabled = !isInventoryOpen;
            }
        }

        public void UpdateInventoryUI()
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }

            foreach (var item in InventoryManager.Instance.items)
            {
                GameObject slot = Instantiate(itemSlotPrefab, content);
                TMP_Text itemName = slot.GetComponentInChildren<TMP_Text>();
                Image itemIcon = slot.transform.Find("ItemIcon").GetComponent<Image>();
                Button itemUseButton = slot.GetComponent<Button>();
                if (itemName != null && itemIcon != null)
                {
                    itemName.text = item.itemName.ToString();
                    itemIcon.sprite = item.itemIcon;
                    itemUseButton.onClick.AddListener(() => OnUseItemButton(item));
                }
            }
        }

        public void OnUseItemButton(Item item)
        {
            Player player = FindFirstObjectByType<Player>();
            if (player != null)
            {
                InventoryManager.Instance.UseItem(item, player);
                UpdateInventoryUI();
            }
            else
            {
                Debug.LogWarning("Không tìm thấy Player trong Scene.");
            }
        }

    }
}
