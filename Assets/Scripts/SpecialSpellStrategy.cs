using UnityEngine;
namespace Hero
{
    public abstract class SpecialSpellStrategy : ScriptableObject
    {
        public string spellName;
        public Sprite spellIcon;
        public int price;
        public abstract void SpecialFire(Transform firePoint, Vector3 target);
    }
}