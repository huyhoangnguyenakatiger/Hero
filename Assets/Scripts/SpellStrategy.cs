using UnityEngine;
namespace Hero
{
    public abstract class SpellStrategy : ScriptableObject
    {
        public abstract void Fire(Transform firePoint);
    }
}