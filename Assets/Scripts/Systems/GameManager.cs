using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hero
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public List<SpecialSpellStrategy> LearnedSpells { get; private set; } = new List<SpecialSpellStrategy>();
        [SerializeField] private int startingMoney = 100;

        public int Money { get; private set; }
        private SpecialSpellStrategy spellUsing;
        public SpecialSpellStrategy GetSpellUsing => spellUsing;
        public void SetSpellUsing(SpecialSpellStrategy spell) => spellUsing = spell;

        public string CurrentScene { get; private set; } = "Base";
        bool isCleared = false;
        const string ENEMIES_LEFT_STRING = "Kẻ thù còn lại: ";
        public int enemiesLeft = 0;
        public void AdjustEnemiesLeft(int amount)
        {
            enemiesLeft += amount;
            if (enemiesLeft <= 0)
            {
                isCleared = true;
            }
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            Money = startingMoney;
        }
        public void LearnSpell(SpecialSpellStrategy spell)
        {
            if (LearnedSpells.Contains(spell)) return;
            LearnedSpells.Add(spell);
            SetSpellUsing(spell);
        }

        public bool SpendMoney(int amount)
        {
            if (Money < amount) return false;
            Money -= amount;
            return true;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public List<SpecialSpellStrategy> GetLearnedSpells()
        {
            return LearnedSpells;
        }

        // Scene management
        public void LoadScene(string sceneName)
        {
            CurrentScene = sceneName;
            SceneManager.LoadScene(sceneName);
        }

    }
}
