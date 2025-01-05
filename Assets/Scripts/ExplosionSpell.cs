using UnityEngine;

namespace Hero
{
    [CreateAssetMenu(fileName = "ExplosionSpell", menuName = "Hero/SpellStrategy/ExplosionSpell")]
    public class ExplosionSpell : SpellStrategy
    {
        public GameObject explosionSpellPrefab;
        public float explosionDamage;
        public float explosionLifeTime;
        public override void Fire(Transform firePoint, Vector3 target)
        {
            GameObject explosionSpell = Instantiate(explosionSpellPrefab, target, Quaternion.identity);
            Explosion explosionComponent = explosionSpell.GetComponent<Explosion>();
            explosionComponent.SetDamage(explosionDamage);

            Destroy(explosionSpell, explosionLifeTime);
        }
    }
}