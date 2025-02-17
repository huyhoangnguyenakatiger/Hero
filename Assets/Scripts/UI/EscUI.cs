using StarterAssets;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Hero
{
    public class EscUI : MonoBehaviour
    {
        [SerializeField] GameObject escPanel;
        [SerializeField] Button quitButton;
        [SerializeField] Button closeButton;
        StarterAssetsInputs starterAssetsInputs;


        void Awake()
        {
            starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            quitButton.onClick.AddListener(() => Application.Quit());
            closeButton.onClick.AddListener(() =>
            {
                escPanel.SetActive(!escPanel.activeSelf);
                TogglePlayerActions(escPanel.activeSelf);
            });
        }


        void Start()
        {
            escPanel.SetActive(false);
        }
        void Update()
        {
             if (starterAssetsInputs != null)
            {
                starterAssetsInputs.IsUIActive = escPanel.activeSelf;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                escPanel.SetActive(!escPanel.activeSelf);
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
