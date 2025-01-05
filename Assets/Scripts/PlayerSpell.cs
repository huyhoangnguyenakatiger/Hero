using StarterAssets;
using UnityEngine;
using UnityEngine.Rendering;
using Utilities;

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
                Vector3 target = InputHelper.GetMouseWorldPositionWithRaycast();
                Debug.Log(target);
                spellStrategy.Fire(firePoint, target);
                starterAssetsInputs.fire = false;
            }
        }
    }
}