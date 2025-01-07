using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class PlayerHUD : MonoBehaviour
    {
        Player player;
        [SerializeField] Image healthBar;

        void Awake()
        {
            player = FindFirstObjectByType<Player>();
        }

        void Update()
        {
            healthBar.fillAmount = player.GetHealthNormalized();
        }
    }
}