using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            if (inventoryPanel.activeSelf)
            {
                UpdateInventoryUI();
            }
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
            Image itemIcon = slot.transform.Find("ItemIcon").GetComponent<Image>();
            if (itemIcon != null)
            {
                itemIcon.sprite = item.itemIcon;
            }
            TMP_Text itemName = slot.GetComponentInChildren<TMP_Text>();
            if (itemIcon != null)
            {
                itemName.text = item.itemName.ToString();
                itemIcon.sprite = item.itemIcon;
            }
        }
    }
}
