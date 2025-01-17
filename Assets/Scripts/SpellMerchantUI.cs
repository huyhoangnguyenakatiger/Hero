using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hero
{
    public class SpellMerchantUI : MonoBehaviour
    {
        SpellMerchant merchant;
        public Transform content;
        public GameObject spellSlotPrefab;
        public GameObject spellPanel;
        public Text playerMoneyText;
        public TooltipManager tooltipManager;
        StarterAssetsInputs starterAssetsInputs;
        // private int playerMoney = 100;
        void Awake()
        {
            merchant = GetComponent<SpellMerchant>();
            // tooltipManager = FindFirstObjectByType<TooltipManager>();
            starterAssetsInputs = FindAnyObjectByType<StarterAssetsInputs>();
        }

        private void Start()
        {
            spellPanel.SetActive(false);
            UpdateMerchantUI();
            // UpdatePlayerMoneyUI();
        }

        void Update()
        {
            if (starterAssetsInputs != null)
            {
                starterAssetsInputs.IsUIActive = spellPanel.activeSelf;
            }
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


                    EventTrigger trigger = slot.AddComponent<EventTrigger>();

                    EventTrigger.Entry pointerEnter = new EventTrigger.Entry
                    {
                        eventID = EventTriggerType.PointerEnter
                    };
                    pointerEnter.callback.AddListener((eventData) =>
                    {
                        tooltipManager.ShowSpellTooltip(spell.spellName, spell.spellDescription, spell.price, spell.manaCost, spell.cooldown, Input.mousePosition);
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

        // public void UpdatePlayerMoneyUI()
        // {
        //     playerMoneyText.text = $"Money: {    }";
        // }
    }
}
