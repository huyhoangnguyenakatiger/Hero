using StarterAssets;
using UnityEngine;

namespace Hero
{
    public class Interactable : MonoBehaviour
    {
        public GameObject spellPanel;
        public SpellMerchantUI spellMerchantUI;
        public GameObject interactUI;
        StarterAssetsInputs starterAssetsInputs;
        private bool isPlayerNearby = false;
        void Awake() => starterAssetsInputs = FindAnyObjectByType<StarterAssetsInputs>();
        private void Start()
        {
            if (interactUI != null)
                interactUI.SetActive(false);
        }

        private void Update()
        {
            if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNearby = true;
                if (interactUI != null)
                    interactUI.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNearby = false;
                if (interactUI != null)
                    interactUI.SetActive(false);
            }
        }

        private void Interact()
        {
            spellPanel.SetActive(!spellPanel.activeSelf);

            TogglePlayerActions(spellPanel.activeSelf);

            if (spellPanel.activeSelf)
            {
                spellMerchantUI.UpdateMerchantUI();

            }
        }

        private void TogglePlayerActions(bool isSpellOpen)
        {
            PlayerSpell playerSpell = FindFirstObjectByType<PlayerSpell>();
            if (playerSpell != null)
            {
                playerSpell.enabled = !isSpellOpen;
            }
            if (starterAssetsInputs != null && !isSpellOpen)
            {
                starterAssetsInputs.fire = false;
                starterAssetsInputs.specialFire = false;
            }
        }
    }
}
