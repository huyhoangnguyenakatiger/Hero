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
        Player player;
        bool isSpellCasting;
        bool isSpecialSpellCasting;
        float spellCooldownTimer;
        float specialSpellCooldownTimer;

        void Awake()
        {
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
            animator = GetComponent<Animator>();
            thirdPersonController = GetComponent<ThirdPersonController>();
            player = FindFirstObjectByType<Player>();
        }

        void Update()
        {
            UpdateCooldownTimers();

            SpecialSpellSelected();

            if (starterAssetsInputs.fire)
            {
                if (!isSpellCasting && spellCooldownTimer <= 0)
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
                if (!isSpecialSpellCasting && specialSpellCooldownTimer <= 0 && specialSpellStrategy && player.mana >= specialSpellStrategy.manaCost)
                {
                    player.UseMana(specialSpellStrategy.manaCost);
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
            isSpellCasting = true;
            // thirdPersonController.enabled = false;
            spellCooldownTimer = spellStrategy.cooldown;

            Vector3 target = InputHelper.GetMouseWorldPositionOnPlane();
            transform.LookAt(target);

            animator.Play("WideArmSpellCasting", 0, 0f);

            if (spellStrategy != null)
            {
                spellStrategy.Fire(firePoint, target);
                AudioManager.Instance.PlaySpellCast();
            }

            Invoke(nameof(EndCastingSpell), spellStrategy.cooldown);
            starterAssetsInputs.fire = false;
        }

        void StartCastingSpecialSpell()
        {
            isSpecialSpellCasting = true;
            // thirdPersonController.enabled = false;
            specialSpellCooldownTimer = specialSpellStrategy.cooldown; // Set cooldown

            Vector3 target = InputHelper.GetMouseWorldPositionOnPlane();
            transform.LookAt(target);

            animator.Play("WideArmSpellCasting", 0, 0f);

            if (GameManager.Instance.GetSpellUsing != null)
            {
                GameManager.Instance.GetSpellUsing.SpecialFire(firePoint, target);
                AudioManager.Instance.PlaySpecialSpellCast();
            }

            Invoke(nameof(EndCastingSpecialSpell), specialSpellStrategy.cooldown);
            starterAssetsInputs.specialFire = false;
        }

        void EndCastingSpell()
        {
            isSpellCasting = false;
            // thirdPersonController.enabled = true;
        }

        void EndCastingSpecialSpell()
        {
            isSpecialSpellCasting = false;
            // thirdPersonController.enabled = true;
        }

        public float GetSpellNormalized() => specialSpellCooldownTimer / GameManager.Instance.GetSpellUsing.cooldown;
    }
}
