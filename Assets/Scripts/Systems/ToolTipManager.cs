using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Hero
{
    public class TooltipManager : MonoBehaviour
    {
        public GameObject tooltipPanel;
        public TMP_Text tooltipDetailsText;
        public TMP_Text tooltipTitleText;
        public TMP_Text tooltipPriceText;
        public TMP_Text tooltipManaCostText;
        public TMP_Text tooltipCooldownText;
        public TMP_Text tooltipDamageText;

        public SpellMerchantUI spellMerchantUI;
        public InventoryUI inventoryUI;
        public SpellUI spellUI;

        private void Start()
        {
            HideTooltip();
        }
        public void HideTooltipIfNoUIOpen()
        {
            if ((spellMerchantUI != null && spellMerchantUI.IsOpen()) ||
                (inventoryUI != null && inventoryUI.IsOpen()) || spellUI != null && spellUI.IsOpen())
            {
                return; // Không ẩn tooltip nếu có UI đang mở
            }
            HideTooltip();
        }

        public void ShowSpellTooltip(string title, string description, int price, float manaCost, float cooldown, float damage, Vector3 position)
        {
            tooltipPanel.SetActive(true);
            tooltipDetailsText.text = description;
            tooltipTitleText.text = title;
            tooltipPriceText.text = "Giá: " + price.ToString();
            tooltipManaCostText.text = "Mana tiêu hao: " + manaCost.ToString();
            tooltipCooldownText.text = "Thời gian hồi chiêu: " + cooldown.ToString() + " Giây";
            tooltipDamageText.text = "Sát thương: " + damage.ToString();
            tooltipPanel.transform.position = position;
        }

        public void ShowItemTooltip(string name, string description, Vector3 position)
        {
            tooltipPanel.SetActive(true);
            tooltipTitleText.text = name;
            tooltipDetailsText.text = description;
            tooltipPanel.transform.position = position;
        }
        public void HideTooltip()
        {
            tooltipPanel.SetActive(false);
            tooltipDetailsText.text = "";
            tooltipTitleText.text = "";
        }
    }
}
