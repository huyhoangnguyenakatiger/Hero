using UnityEngine;

namespace Hero
{
    public class EnemyFactory : MonoBehaviour
    {
        public Enemy CreateEnemy(EnemyData enemyData, Transform spawnPosition)
        {
            if (enemyData.enemyPrefab == null)
            {
                return null;
            }

            Enemy enemyComponent = new EnemyBuilder()
            .WithPrefab(enemyData.enemyPrefab)
            .WithName(enemyData.enemyName)
            .WithHealth(enemyData.health)
            .WithSpeed(enemyData.speed)
            .WithDamage(enemyData.damage)
            .WithSpawnPosition(spawnPosition)
            .Build();


            return enemyComponent;
        }
    }
}