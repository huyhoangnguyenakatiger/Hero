using StarterAssets;
using UnityEngine;
using Utilities;

namespace Hero
{
    public class PlayerSpell : Spell
    {
        [SerializeField] Transform firePoint;
        StarterAssetsInputs starterAssetsInputs;
        Animator animator;
        ThirdPersonController thirdPersonController;
        bool isCasting;

        void Awake()
        {
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
            animator = GetComponent<Animator>();
            thirdPersonController = GetComponent<ThirdPersonController>();
        }

        void Update()
        {
            if (starterAssetsInputs.fire && !isCasting)
            {
                StartCastingSpell();
            }
        }

        void StartCastingSpell()
        {
            isCasting = true;
            thirdPersonController.enabled = false;

            Vector3 target = InputHelper.GetMouseWorldPositionOnPlane();
            transform.LookAt(target);

            animator.Play("WideArmSpellCasting", 0, 0f);

            if (spellStrategy != null)
            {
                spellStrategy.Fire(firePoint, target);
            }
            Invoke(nameof(EndCastingSpell), 1.5f);
            starterAssetsInputs.fire = false;
        }

        void EndCastingSpell()
        {
            isCasting = false;
            thirdPersonController.enabled = true;
        }
    }
}
