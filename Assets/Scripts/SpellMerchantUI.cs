using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class SpellMerchantUI : MonoBehaviour
    {
        public SpellMerchant merchant;
        public Transform content;
        public GameObject spellSlotPrefab;
        public GameObject spellPanel;
        public Text playerMoneyText;

        // private int playerMoney = 100;


        private void Start()
        {
            spellPanel.SetActive(false);
            UpdateMerchantUI();
            // UpdatePlayerMoneyUI();
        }

        public void UpdateMerchantUI()
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }

            foreach (var spell in merchant.spellsForSale)
            {
                GameObject slot = Instantiate(spellSlotPrefab, content);
                TMP_Text spellName = slot.transform.Find("SpellName").GetComponent<TMP_Text>();
                TMP_Text spellPrice = slot.transform.Find("SpellPrice").GetComponent<TMP_Text>();
                Image spellIcon = slot.transform.Find("SpellIcon").GetComponent<Image>();
                Button spellBuyButton = slot.GetComponent<Button>();
                if (spellName != null && spellIcon != null)
                {
                    spellName.text = spell.spellName.ToString();
                    spellIcon.sprite = spell.spellIcon;
                    spellPrice.text = spell.price.ToString();
                    spellBuyButton.onClick.AddListener(() => merchant.BuySpell(spell, spell.price));
                }
            }
        }

        // public void UpdatePlayerMoneyUI()
        // {
        //     playerMoneyText.text = $"Money: {playerMoney}";
        // }
    }
}
