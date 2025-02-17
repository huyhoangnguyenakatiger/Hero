using System.Collections.Generic;
using UnityEngine;

namespace Hero
{
    public class SpellMerchant : MonoBehaviour
    {

        public List<SpecialSpellStrategy> spellsForSale = new List<SpecialSpellStrategy>();
        [SerializeField] NotificationUI notificationUI;

        public bool BuySpell(SpecialSpellStrategy spell, int price)
        {
            // Kiểm tra nếu đã học kỹ năng rồi
            if (GameManager.Instance.LearnedSpells.Contains(spell))
            {
                notificationUI.ShowMessage("Bạn đã học kỹ năng này rồi!!!");
                return false;
            }

            // Nếu chưa học, mới kiểm tra tiền và học kỹ năng
            if (GameManager.Instance.SpendMoney(price))
            {
                GameManager.Instance.LearnSpell(spell);
                return true;
            }

            notificationUI.ShowMessage("Bạn không đủ tiền!!!");
            return false;
        }


    }
}
