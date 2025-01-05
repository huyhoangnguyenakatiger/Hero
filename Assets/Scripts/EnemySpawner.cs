using UnityEngine;

namespace Hero
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] EnemyData enemyData;

        [SerializeField] float spawnInterval = 3f;
        EnemyFactory enemyFactory;
        float spawnTimer = 0f;
        void Start()
        {
            enemyFactory = new EnemyFactory();
        }

        // Update is called once per frame
        void Update()
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnInterval)
            {
                enemyFactory.CreateEnemy(enemyData, transform);
                spawnTimer = 0f;
            }
        }
    }
}
