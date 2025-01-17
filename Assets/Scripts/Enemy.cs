using UnityEngine;

namespace Hero
{
    public class Enemy : Character
    {
        public float speed;
        public float damage;
        [SerializeField] GameObject explosionPrefab;
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
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            GameManager.Instance.AdjustEnemiesLeft(-1);
            Destroy(gameObject);
        }

    }
}