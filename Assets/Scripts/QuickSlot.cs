using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class QuickSlot : MonoBehaviour
    {
        [SerializeField] public Item item;
        public Image image;

        public TMP_Text quantity;

        void Start()
        {
            if (item != null && image != null && quantity != null)
            {
                image.sprite = item.itemIcon;
                quantity.text = item.quantity.ToString();
            }
            else
            {
                Debug.Log("Item, Image or Quantity is not assigned!");
            }
        }

        void Update()
        {
            if (item != null && quantity != null)
            {
                if (item.quantity > 0)
                {
                    quantity.text = item.quantity.ToString();
                }
                else
                {
                    quantity.text = "0";
                }
            }
            else
            {
                Debug.Log("Item or Quantity is not assigned!");
            }
        }

    }
}