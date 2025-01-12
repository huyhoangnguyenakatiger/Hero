using UnityEngine;

namespace Hero
{
    public class Portal : MonoBehaviour
    {
        public string targetScene;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.LoadScene(targetScene);
            }
        }

        void Update()
        {
            if (GameManager.Instance.enemiesLeft <= 0)
            {
                gameObject.SetActive(true);
            }
        }
    }

}