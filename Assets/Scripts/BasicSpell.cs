using UnityEngine;
namespace Hero
{
    [CreateAssetMenu(fileName = "BasicSpell", menuName = "Hero/SpellStrategy/BasicSpell")]
    public class BasicSpell : SpellStrategy
    {
        public GameObject projectilePrefab;
        public GameObject projectileHit;
        public float projectileLifeTime;
        public float projectileSpeed;
        public float projectileDamage;
        public override void Fire(Transform firePoint, Vector3 target)
        {
            target.y = firePoint.position.y;
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.gameObject.transform.LookAt(target);
            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetProjectileSpeed(projectileSpeed);
            projectileComponent.SetProjectileDamage(projectileDamage);
            projectileComponent.SetProjectileHit(projectileHit);
            Destroy(projectile, projectileLifeTime);
        }
    }
}