using UnityEngine;

namespace Hero
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Hero/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public string enemyName;
        public float health;
        public float speed;
        public float damage;
        public GameObject enemyPrefab;
    }
}