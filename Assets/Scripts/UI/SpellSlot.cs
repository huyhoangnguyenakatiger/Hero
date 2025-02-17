using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class SpellSlot : MonoBehaviour
    {
        public Image spell;
        public Image cooldown;
        PlayerSpell playerSpell;
        void Awake() => playerSpell = FindFirstObjectByType<PlayerSpell>();
        void Start()
        {

            if (GameManager.Instance.GetSpellUsing != null && spell != null)
            {
                spell.sprite = GameManager.Instance.GetSpellUsing.spellIcon;
            }
            else
            {
                Debug.Log("Không có kỹ năng");
            }

        }

        void Update()
        {

            if (GameManager.Instance.GetSpellUsing != null && spell != null && cooldown != null)
            {
                spell.sprite = GameManager.Instance.GetSpellUsing.spellIcon;
                cooldown.fillAmount = playerSpell.GetSpellNormalized();
            }
        }
    }

}