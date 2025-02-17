using UnityEngine;

namespace Hero
{
    [CreateAssetMenu(fileName = "ExplosionSpell", menuName = "Hero/SpecialSpellStrategy/ExplosionSpell")]
    public class ExplosionSpell : SpecialSpellStrategy
    {
        public GameObject explosionSpellPrefab;
        public float explosionLifeTime;
        public override void SpecialFire(Transform firePoint, Vector3 target)
        {
            GameObject explosionSpell = Instantiate(explosionSpellPrefab, target, Quaternion.identity);
            Explosion explosionComponent = explosionSpell.GetComponent<Explosion>();
            explosionComponent.SetDamage(damage);

            Destroy(explosionSpell, explosionLifeTime);

        }
    }
}