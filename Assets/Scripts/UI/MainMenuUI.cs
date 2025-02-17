using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] string targetScene;
        [SerializeField] Button playButton;
        [SerializeField] Button quitButton;
        [SerializeField] GameObject tutorialUI;
        [SerializeField] Button tutorialButton;
        [SerializeField] Button closeTutorialButton;


        void Awake()
        {
            playButton.onClick.AddListener(() => GameManager.Instance.LoadScene(targetScene));
            quitButton.onClick.AddListener(() => Application.Quit());
            tutorialButton.onClick.AddListener(() => tutorialUI.SetActive(true));
            closeTutorialButton.onClick.AddListener(() => tutorialUI.SetActive(false));
        }
    }
}