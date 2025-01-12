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
        float spellCooldownTimer;
        float specialSpellCooldownTimer;

        void Awake()
        {
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
            animator = GetComponent<Animator>();
            thirdPersonController = GetComponent<ThirdPersonController>();
        }

        void Update()
        {
            UpdateCooldownTimers();

            SpecialSpellSelected();

            if (starterAssetsInputs.fire)
            {
                if (!isCasting && spellCooldownTimer <= 0)
                {
                    StartCastingSpell();
                }
                else
                {
                    starterAssetsInputs.fire = false;
                }
            }

            if (starterAssetsInputs.specialFire)
            {
                if (!isCasting && specialSpellCooldownTimer <= 0 && specialSpellStrategy)
                {
                    StartCastingSpecialSpell();
                }
                else
                {
                    starterAssetsInputs.specialFire = false;
                }
            }
        }


        void UpdateCooldownTimers()
        {
            if (spellCooldownTimer > 0)
                spellCooldownTimer -= Time.deltaTime;

            if (specialSpellCooldownTimer > 0)
                specialSpellCooldownTimer -= Time.deltaTime;
        }

        void SpecialSpellSelected()
        {
            if (GameManager.Instance.GetSpellUsing != null)
            {
                specialSpellStrategy = GameManager.Instance.GetSpellUsing;
            }
        }

        void StartCastingSpell()
        {
            isCasting = true;
            thirdPersonController.enabled = false;
            spellCooldownTimer = spellStrategy.cooldown;

            Vector3 target = InputHelper.GetMouseWorldPositionOnPlane();
            transform.LookAt(target);

            animator.Play("WideArmSpellCasting", 0, 0f);

            if (spellStrategy != null)
            {
                spellStrategy.Fire(firePoint, target);
            }

            Invoke(nameof(EndCastingSpell), spellStrategy.cooldown);
            starterAssetsInputs.fire = false;
        }

        void StartCastingSpecialSpell()
        {
            isCasting = true;
            thirdPersonController.enabled = false;
            specialSpellCooldownTimer = specialSpellStrategy.cooldown; // Set cooldown

            Vector3 target = InputHelper.GetMouseWorldPositionOnPlane();
            transform.LookAt(target);

            animator.Play("WideArmSpellCasting", 0, 0f);

            if (specialSpellStrategy != null)
            {
                specialSpellStrategy.SpecialFire(firePoint, target);
            }

            Invoke(nameof(EndCastingSpell), specialSpellStrategy.cooldown);
            starterAssetsInputs.specialFire = false;
        }

        void EndCastingSpell()
        {
            isCasting = false;
            thirdPersonController.enabled = true;
        }
    }
}
