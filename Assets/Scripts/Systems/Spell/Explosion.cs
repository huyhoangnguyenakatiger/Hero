using UnityEngine;

namespace Hero
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float aoeRadius = 3f;
        private float damage;
        private ParticleSystem ps;
        private bool hasExploded = false;

        public void SetDamage(float damage) => this.damage = damage;

        void Awake() => ps = GetComponentInChildren<ParticleSystem>();

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, aoeRadius);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (hasExploded) return;
            hasExploded = true;

            int enemyLayerMask = LayerMask.GetMask("Enemy");

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, aoeRadius, enemyLayerMask);
            foreach (Collider hitCollider in hitColliders)
            {
                Character characterComponent = hitCollider.GetComponent<Character>();
                if (characterComponent != null)
                {
                    characterComponent.TakeDamage(damage);
                }
            }

            Collider collider = GetComponent<Collider>();
            if (collider != null) Destroy(collider);

            if (ps != null)
            {
                Destroy(gameObject, ps.main.duration);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
