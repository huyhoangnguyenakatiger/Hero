using StarterAssets;
using UnityEngine;

namespace Hero
{
    public class PlayerSpell : Spell
    {
        [SerializeField] Transform firePoint;
        StarterAssetsInputs starterAssetsInputs;

        void Awake()
        {
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        }

        void Update()
        {
            if (starterAssetsInputs.fire)
            {
                spellStrategy.Fire(firePoint);
                starterAssetsInputs.fire = false;
            }
        }
    }
}