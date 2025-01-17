using UnityEngine;

namespace Hero
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        AudioSource audioSource;

        [SerializeField] AudioClip background;
        [SerializeField] AudioClip spellCast;
        [SerializeField] AudioClip specialSpellCast;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayBackground()
        {
            audioSource.clip = background;
            audioSource.Play();
        }
        public void PlaySpellCast() => audioSource.PlayOneShot(spellCast);
        public void PlaySpecialSpellCast() => audioSource.PlayOneShot(specialSpellCast);

    }
}