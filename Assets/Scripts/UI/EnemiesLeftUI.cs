using TMPro;
using UnityEngine;

namespace Hero
{
    public class EnemiesLeftUI : MonoBehaviour
    {
        TMP_Text enemiesLeftText;

        void Awake()
        {
            enemiesLeftText = GetComponentInChildren<TMP_Text>();
        }
        void Update()
        {
            enemiesLeftText.text = "KẺ ĐỊCH CÒN LẠI: " + GameManager.Instance.enemiesLeft.ToString();
        }
    }
}
