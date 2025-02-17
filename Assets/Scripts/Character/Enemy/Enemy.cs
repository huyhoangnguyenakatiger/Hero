using UnityEngine;

namespace Hero
{
    public class Enemy : Character
    {
        public float speed;
        public float damage;
        [SerializeField] GameObject explosionPrefab;
        [SerializeField] GameObject[] dropItems;
        [SerializeField] int money = 10;
        [SerializeField] float dropChance = 0.5f;
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
            GameManager.Instance.AddMoney(money);
            DropItem();
            GameManager.Instance.AdjustEnemiesLeft(-1);
            Destroy(gameObject);
        }

        void DropItem()
        {
            if (dropItems.Length > 0 && Random.value <= dropChance)
            {
                // Chọn ngẫu nhiên một item từ danh sách
                int randomIndex = Random.Range(0, dropItems.Length);
                Instantiate(dropItems[randomIndex], transform.position, Quaternion.identity);
            }
        }

    }
}