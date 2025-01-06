using UnityEngine;

namespace Hero
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] public float maxHealth;
        public float health;
        public abstract void TakeDamage(float amount);
        public abstract void Die();

    }
}