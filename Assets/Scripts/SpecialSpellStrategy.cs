using UnityEngine;
namespace Hero
{
    public abstract class SpecialSpellStrategy : ScriptableObject
    {
        public string spellName;
        public string spellDescription;
        public Sprite spellIcon;
        public float cooldown;
        public float manaCost;
        public int price;
        public abstract void SpecialFire(Transform firePoint, Vector3 target);
    }
}