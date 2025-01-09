using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class SpellUI : MonoBehaviour
    {
        public GameObject spellPanel;
        public Transform content;
        public GameObject spellSlotPrefab;

        private void Start()
        {
            spellPanel.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                spellPanel.SetActive(!spellPanel.activeSelf);

                TogglePlayerActions(spellPanel.activeSelf);

                if (spellPanel.activeSelf)
                {
                    UpdateSpellUI();
                }
            }
        }

        private void TogglePlayerActions(bool isSpellOpen)
        {
            PlayerSpell playerSpell = FindFirstObjectByType<PlayerSpell>();
            if (playerSpell != null)
            {
                playerSpell.enabled = !isSpellOpen;
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
