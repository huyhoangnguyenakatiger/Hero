using System.Collections.Generic;
using UnityEngine;

namespace Hero
{
    public class SpellMerchant : MonoBehaviour
    {

        public List<SpecialSpellStrategy> spellsForSale = new List<SpecialSpellStrategy>();

        public bool BuySpell(SpecialSpellStrategy spell, int price)
        {
            if (GameManager.Instance.SpendMoney(price))
            {
                GameManager.Instance.LearnSpell(spell);
                return true;
            }
            return false;
        }

    }
}
