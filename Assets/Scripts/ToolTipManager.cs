using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class TooltipManager : MonoBehaviour
    {
        public GameObject tooltipPanel;
        public TMP_Text tooltipDetailsText;
        public TMP_Text tooltipTitleText;

        private void Start()
        {
            HideTooltip();
        }

        public void ShowTooltip(string title, string description, Vector3 position)
        {
            tooltipPanel.SetActive(true);
            tooltipDetailsText.text = description;
            tooltipTitleText.text = title;
            tooltipPanel.transform.position = position;
        }

        public void HideTooltip()
        {
            tooltipPanel.SetActive(false);
            tooltipDetailsText.text = "";
            tooltipTitleText.text = "";
        }
    }
}
