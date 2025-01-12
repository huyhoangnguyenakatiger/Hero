using UnityEngine;

namespace Hero
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] EnemyData enemyData;
        [SerializeField] int maxEnemies = 5;
        [SerializeField] float spawnInterval = 3f;
        EnemyFactory enemyFactory;
        float spawnTimer = 0f;
        int enemiesSpawned = 0;
        void Start()
        {
            enemyFactory = new EnemyFactory();
        }

        void Update()
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnInterval && enemiesSpawned <= maxEnemies)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
            if (enemiesSpawned == maxEnemies)
            {
                Destroy(gameObject);
            }
        }

        private void SpawnEnemy()
        {
            enemyFactory.CreateEnemy(enemyData, transform);
            enemiesSpawned++;
            GameManager.Instance.AdjustEnemiesLeft(1);
        }
    }
}
