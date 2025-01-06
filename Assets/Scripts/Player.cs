using UnityEngine;

namespace Hero
{
    public class Player : Character
    {
        void Awake()
        {
            health = maxHealth;
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
    }
}