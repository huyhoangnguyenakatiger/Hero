using UnityEngine;

namespace Hero
{
    public class Portal : MonoBehaviour
    {
        public string targetScene;
        [SerializeField] private GameObject portalObject;

        // private void Start()
        // {
        //     if (portalObject != null)
        //         portalObject.SetActive(false);
        // }

        // private void Update()
        // {
        //     if (GameManager.Instance.enemiesLeft == 0)
        //     {
        //         portalObject.SetActive(true);
        //     }
        // }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.LoadScene(targetScene);
            }
        }
    }
}
