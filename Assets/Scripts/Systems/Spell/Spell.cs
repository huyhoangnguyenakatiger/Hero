using UnityEngine;

namespace Hero
{
    public abstract class Spell : MonoBehaviour
    {
        [SerializeField] protected SpellStrategy spellStrategy;

        [SerializeField] protected SpecialSpellStrategy specialSpellStrategy;
    }
}
