using UnityEngine;
using TMPro;
using System.Collections;

namespace Hero
{
    public class NotificationUI : MonoBehaviour
    {
        public TextMeshProUGUI notificationText;
        public float displayTime = 2f;

        private Coroutine currentCoroutine;

        public void ShowMessage(string message)
        {
            notificationText.text = message;
            gameObject.SetActive(true);

            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = StartCoroutine(HideAfterDelay());
        }
        private IEnumerator HideAfterDelay()
        {
            yield return new WaitForSeconds(displayTime);
            gameObject.SetActive(false);
        }
    }
}