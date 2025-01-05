using UnityEngine;

namespace Hero
{
    public class Projectile : MonoBehaviour
    {
        float projectileSpeed;
        float projectileDamage;
        public void SetProjectileSpeed(float projectileSpeed) => this.projectileSpeed = projectileSpeed;
        public void SetProjectileDamage(float projectileDamage) => this.projectileDamage = projectileDamage;
        void Start()
        {

        }

        void Update()
        {
            transform.position += transform.forward * (projectileSpeed * Time.deltaTime);
        }
    }
}