using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hero
{
    public class InventoryUI : MonoBehaviour
    {
        public GameObject inventoryPanel;
        public Transform content;
        public GameObject itemSlotPrefab;
        public TooltipManager tooltipManager;


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
            if (!inventoryPanel.activeSelf)
            {
                tooltipManager.HideTooltipIfNoUIOpen();
            }

        }

        public bool IsOpen()
        {
            return inventoryPanel.activeSelf;
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

                TMP_Text itemName = slot.transform.Find("ItemName").GetComponent<TMP_Text>();
                Image itemIcon = slot.transform.Find("ItemIcon").GetComponent<Image>();
                TMP_Text itemQuantity = slot.transform.Find("ItemQuantity").GetComponent<TMP_Text>();
                Button itemUseButton = slot.GetComponent<Button>();

                Button assignButton = slot.transform.Find("AssignButton").GetComponent<Button>();

                if (itemName != null && itemIcon != null)
                {
                    itemName.text = item.itemName.ToString();
                    itemIcon.sprite = item.itemIcon;
                    itemQuantity.text = item.quantity.ToString();
                    itemUseButton.onClick.AddListener(() => OnUseItemButton(item));

                    EventTrigger trigger = slot.AddComponent<EventTrigger>();

                    EventTrigger.Entry pointerEnter = new EventTrigger.Entry
                    {
                        eventID = EventTriggerType.PointerEnter
                    };
                    pointerEnter.callback.AddListener((eventData) =>
                    {
                        tooltipManager.ShowItemTooltip(item.itemName, item.itemDescription, Input.mousePosition);
                    });
                    trigger.triggers.Add(pointerEnter);

                    // PointerExit
                    EventTrigger.Entry pointerExit = new EventTrigger.Entry
                    {
                        eventID = EventTriggerType.PointerExit
                    };
                    pointerExit.callback.AddListener((eventData) =>
                    {
                        tooltipManager.HideTooltip();
                    });
                    trigger.triggers.Add(pointerExit);
                }
            }
        }

        public void OnUseItemButton(Item item)
        {
            Player player = FindFirstObjectByType<Player>();
            if (player != null)
            {
                InventoryManager.Instance.UseItem(item, player);
                if (item.quantity <= 0)
                {
                    tooltipManager.HideTooltip();
                }
                UpdateInventoryUI();
            }
            else
            {
                Debug.Log("Không tìm thấy Player trong Scene.");
            }
        }
    }
}
