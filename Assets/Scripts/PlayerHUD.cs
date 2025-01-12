using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class PlayerHUD : MonoBehaviour
    {
        Player player;
        [SerializeField] Image healthBar;
        [SerializeField] TMP_Text moneyText;

        void Awake()
        {
            player = FindFirstObjectByType<Player>();
        }

        void Update()
        {
            healthBar.fillAmount = player.GetHealthNormalized();
            moneyText.text = GameManager.Instance.Money.ToString();
        }
    }
}