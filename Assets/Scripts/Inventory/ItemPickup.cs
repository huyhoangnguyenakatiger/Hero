using UnityEngine;

namespace Hero
{
    public class PickupItem : MonoBehaviour
    {
        public Item item;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                InventoryManager.Instance.AddItem(item);
                Destroy(gameObject);
            }
        }
    }
}
