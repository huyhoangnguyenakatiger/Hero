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

        // New fields for scene management
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
            if (!LearnedSpells.Contains(spell))
            {
                LearnedSpells.Add(spell);
                SetSpellUsing(spell);
                Debug.Log($"Spell {spell.name} learned!");
            }
        }

        public bool SpendMoney(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                Debug.Log($"Spent {amount} money. Remaining: {Money}");
                return true;
            }
            Debug.Log("Not enough money!");
            return false;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
            Debug.Log($"Gained {amount} money. Total: {Money}");
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
