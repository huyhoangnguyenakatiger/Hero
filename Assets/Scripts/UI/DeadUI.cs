using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Hero
{
    public class DeadUI : MonoBehaviour
    {
        [SerializeField] string targetScene;
        [SerializeField] GameObject deadPanel;
        [SerializeField] Button reloadButton;
        [SerializeField] Button quitButton;
        Player player;

        void Awake()
        {
            player = FindFirstObjectByType<Player>();
            reloadButton.onClick.AddListener(() => GameManager.Instance.LoadScene(targetScene));
            quitButton.onClick.AddListener(() => Application.Quit());
        }

        void Update()
        {
            if (player.health <= 0)
            {
                deadPanel.SetActive(true);
            }
        }

    }
}