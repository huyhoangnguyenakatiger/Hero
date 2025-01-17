using UnityEngine;

namespace Hero
{
    public class EnemyFactory
    {
        public GameObject CreateEnemy(EnemyData enemyData, Transform spawnPosition)
        {
            if (enemyData.enemyPrefab == null)
            {
                return null;
            }

            EnemyBuilder builder = new EnemyBuilder()
            .WithPrefab(enemyData.enemyPrefab)
            .WithName(enemyData.enemyName)
            .WithHealth(enemyData.health)
            .WithSpeed(enemyData.speed)
            .WithDamage(enemyData.damage)
            .WithSpawnPosition(spawnPosition);


            return builder.Build();
        }
    }
}