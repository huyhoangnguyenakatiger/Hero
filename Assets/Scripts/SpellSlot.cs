using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class SpellSlot : MonoBehaviour
    {
        public Image image;
        void Start()
        {
            if (GameManager.Instance.GetSpellUsing != null && image != null)
            {
                image.sprite = GameManager.Instance.GetSpellUsing.spellIcon;
            }
            else
            {
                Debug.Log("Không có kỹ năng");
            }
        }

        void Update()
        {
            if (GameManager.Instance.GetSpellUsing != null && image != null)
            {
                image.sprite = GameManager.Instance.GetSpellUsing.spellIcon;
            }
        }
    }

}