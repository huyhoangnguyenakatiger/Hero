using System.Collections.Generic;
using UnityEngine;

namespace Hero
{
    public class SpellMerchant : MonoBehaviour
    {

        public List<SpellStrategy> spellsForSale = new List<SpellStrategy>();

        public bool BuySpell(SpellStrategy spell, int price)
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
