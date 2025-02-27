using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using StarterAssets;

namespace Hero
{
    public class SpellUI : MonoBehaviour
    {
        public GameObject spellPanel;
        public Transform content;
        public GameObject spellSlotPrefab;
        public TooltipManager tooltipManager;
        StarterAssetsInputs starterAssetsInputs;

        void Awake() => starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        private void Start()
        {
            spellPanel.SetActive(false);
        }

        private void Update()
        {
            if (starterAssetsInputs != null)
            {
                starterAssetsInputs.IsUIActive = spellPanel.activeSelf;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                spellPanel.SetActive(!spellPanel.activeSelf);

                TogglePlayerActions(spellPanel.activeSelf);

                if (spellPanel.activeSelf)
                {
                    UpdateSpellUI();
                }
            }
            if (!spellPanel.activeSelf)
            {
                tooltipManager.HideTooltipIfNoUIOpen();
            }
        }

        public bool IsOpen()
        {
            return spellPanel.activeSelf;
        }


        private void TogglePlayerActions(bool isSpellOpen)
        {
            PlayerSpell playerSpell = FindFirstObjectByType<PlayerSpell>();
            if (playerSpell != null)
            {
                playerSpell.enabled = !isSpellOpen;
            }
            if (starterAssetsInputs != null && !isSpellOpen)
            {
                starterAssetsInputs.fire = false;
                starterAssetsInputs.specialFire = false;
            }
        }


        public void UpdateSpellUI()
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }

            foreach (var spell in GameManager.Instance.LearnedSpells)
            {
                GameObject slot = Instantiate(spellSlotPrefab, content);
                TMP_Text spellName = slot.GetComponentInChildren<TMP_Text>();
                Image spellIcon = slot.transform.Find("SpellIcon").GetComponent<Image>();
                Button spellSelectButton = slot.GetComponent<Button>();

                if (spellName != null && spellIcon != null)
                {
                    spellName.text = spell.spellName.ToString();
                    spellIcon.sprite = spell.spellIcon;
                    spellSelectButton.onClick.AddListener(() => OnSetSpellUsing(spell));

                    EventTrigger trigger = slot.AddComponent<EventTrigger>();

                    EventTrigger.Entry pointerEnter = new EventTrigger.Entry
                    {
                        eventID = EventTriggerType.PointerEnter
                    };
                    pointerEnter.callback.AddListener((eventData) =>
                    {
                        tooltipManager.ShowSpellTooltip(spell.spellName, spell.spellDescription, spell.price, spell.manaCost, spell.cooldown, spell.damage, Input.mousePosition);
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

        public void OnSetSpellUsing(SpecialSpellStrategy spell)
        {
            PlayerSpell playerSpell = FindFirstObjectByType<PlayerSpell>();
            if (playerSpell != null)
            {
                GameManager.Instance.SetSpellUsing(spell);
            }
            else
            {
                Debug.LogWarning("Không tìm thấy Player trong Scene.");
            }
        }
    }
}
