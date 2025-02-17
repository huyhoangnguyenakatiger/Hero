using UnityEngine;

namespace Hero
{
    public class EnemySpell : Spell
    {
        EnemyAI enemyAI;
        [SerializeField] Transform fireInput;
        void Awake()
        {
            enemyAI = GetComponent<EnemyAI>();
        }
        void OnEnable()
        {
            if (enemyAI != null) enemyAI.Fire += OnFire;
        }

        void OnDisable()
        {
            if (enemyAI != null) enemyAI.Fire -= OnFire;
        }

        void OnFire(Transform player)
        {
            Vector3 target = player.position;
            if (spellStrategy != null)
            {
                spellStrategy.Fire(fireInput, target);
                AudioManager.Instance.PlayEnemySpellCast();
            }
        }


    }
}