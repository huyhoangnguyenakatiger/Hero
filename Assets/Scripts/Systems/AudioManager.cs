using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hero
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        private AudioSource audioSource;

        [Header("Background Music")]
        [SerializeField] AudioClip mainMenuSceneMusic;
        [SerializeField] AudioClip baseSceneMusic;
        [SerializeField] AudioClip forest1Music;
        [SerializeField] AudioClip forest2Music;

        [Header("Sound Effects")]
        [SerializeField] AudioClip spellCast;
        [SerializeField] AudioClip specialSpellCast;
        [SerializeField] AudioClip enemySpellCast;
        [SerializeField] AudioClip drink;
        [SerializeField] AudioClip die;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                audioSource = GetComponent<AudioSource>();

                PlayInitialBackground();
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }
        }

        private void PlayInitialBackground()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            switch (currentSceneName)
            {
                case "MainMenu":
                    PlayBackground(mainMenuSceneMusic);
                    break;
                case "Base":
                    PlayBackground(baseSceneMusic);
                    break;
                case "Forrest1":
                    PlayBackground(forest1Music);
                    break;
                case "Forrest2":
                    PlayBackground(forest2Music);
                    break;
                default:
                    Debug.LogWarning($"No background music assigned for scene: {currentSceneName}");
                    break;
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            switch (scene.name)
            {
                case "MainMenu":
                    PlayBackground(mainMenuSceneMusic);
                    break;
                case "Base":
                    PlayBackground(baseSceneMusic);
                    break;
                case "Forrest1":
                    PlayBackground(forest1Music);
                    break;
                case "Forrest2":
                    PlayBackground(forest2Music);
                    break;
                default:
                    Debug.LogWarning($"No background music assigned for scene: {scene.name}");
                    break;
            }
        }

        public void PlayBackground(AudioClip clip)
        {
            if (audioSource.clip == clip) return; // Tránh phát lại nhạc giống nhau
            audioSource.clip = clip;
            audioSource.loop = true; // Đảm bảo nhạc nền được lặp lại
            audioSource.Play();
        }

        public void PlaySpellCast() => audioSource.PlayOneShot(spellCast);

        public void PlaySpecialSpellCast() => audioSource.PlayOneShot(specialSpellCast);
        public void PlayEnemySpellCast() => audioSource.PlayOneShot(enemySpellCast);
        public void PlayDrink() => audioSource.PlayOneShot(drink);
        public void PlayDie() => audioSource.PlayOneShot(die);
    }
}
