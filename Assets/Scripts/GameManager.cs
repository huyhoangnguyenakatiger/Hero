using System.Collections.Generic;
using UnityEngine;

namespace Hero
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public List<SpellStrategy> LearnedSpells { get; private set; } = new List<SpellStrategy>();

        [SerializeField] private SpellStrategy basicSpell;
        [SerializeField] private int startingMoney = 100;

        public int Money { get; private set; }

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

            if (basicSpell != null && !LearnedSpells.Contains(basicSpell))
            {
                LearnedSpells.Add(basicSpell);
            }
        }

        public void LearnSpell(SpellStrategy spell)
        {
            if (!LearnedSpells.Contains(spell))
            {
                LearnedSpells.Add(spell);
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

        public List<SpellStrategy> GetLearnedSpells()
        {
            return LearnedSpells;
        }
    }
}
