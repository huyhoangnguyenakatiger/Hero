using UnityEngine;

namespace Hero
{
    public class EnemyBuilder
    {
        public GameObject enemyPrefab;
        public string enemyName;
        public float health;
        public float speed;
        public float damage;
        public Transform spawnPosition;

        public EnemyBuilder WithPrefab(GameObject enemyPrefab)
        {
            this.enemyPrefab = enemyPrefab;
            return this;
        }
        public EnemyBuilder WithName(string enemyName)
        {
            this.enemyName = enemyName;
            return this;
        }

        public EnemyBuilder WithHealth(float health)
        {
            this.health = health;
            return this;
        }

        public EnemyBuilder WithSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }

        public EnemyBuilder WithDamage(float damage)
        {
            this.damage = damage;
            return this;
        }

        public EnemyBuilder WithSpawnPosition(Transform spawnPosition)
        {
            this.spawnPosition = spawnPosition;
            return this;
        }

        public GameObject Build()
        {
            GameObject enemyObject = GameObject.Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);

            Enemy enemyComponent = enemyObject.GetComponent<Enemy>();
            enemyComponent.health = health;
            enemyComponent.speed = speed;
            enemyComponent.damage = damage;
            return enemyObject;
        }
    }
}