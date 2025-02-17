using UnityEngine;

namespace Hero
{
    public class Projectile : MonoBehaviour
    {
        float projectileSpeed;
        float projectileDamage;
        GameObject projectileHit;
        public void SetProjectileSpeed(float projectileSpeed) => this.projectileSpeed = projectileSpeed;
        public void SetProjectileDamage(float projectileDamage) => this.projectileDamage = projectileDamage;
        public void SetProjectileHit(GameObject projectileHit) => this.projectileHit = projectileHit;
        void Start()
        {

        }

        void Update()
        {
            transform.position += transform.forward * (projectileSpeed * Time.deltaTime);
        }

        void OnCollisionEnter(Collision other)
        {
            if (projectileHit != null)
            {
                ContactPoint contact = other.contacts[0];
                GameObject hitVFX = Instantiate(projectileHit, contact.point, Quaternion.identity);

                DestroyParticleSystem(hitVFX);
            }
            Character characterComponent = other.gameObject.GetComponent<Character>();
            if (characterComponent != null)
            {
                characterComponent.TakeDamage(projectileDamage);
            }

            Destroy(gameObject);
        }

        void DestroyParticleSystem(GameObject vfx)
        {
            var ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }
            Destroy(vfx, ps.main.duration);
        }
    }
}