using UnityEngine;
namespace Hero
{
    public abstract class SpellStrategy : ScriptableObject
    {
        public string spellName;
        public Sprite spellIcon;
        public float cooldown;
        public int price;
        public abstract void Fire(Transform firePoint, Vector3 target);
    }
}