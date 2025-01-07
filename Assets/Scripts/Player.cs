using UnityEngine;

namespace Hero
{
    public class Player : Character
    {
        public float mana;
        public float maxMana;

        void Awake()
        {
            health = maxHealth;
            mana = maxMana;
        }

        public override void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }

        public override void Die()
        {
            Destroy(gameObject);
        }

        public void Heal(float amount)
        {
            health = Mathf.Clamp(health + amount, 0, maxHealth);
        }

        public void RestoreMana(float amount)
        {
            mana = Mathf.Clamp(mana + amount, 0, maxMana);
        }
    }
}
