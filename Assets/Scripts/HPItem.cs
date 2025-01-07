using UnityEngine;

namespace Hero
{
    [CreateAssetMenu(fileName = "New HP Item", menuName = "Hero/Items/HP Item")]
    public class HPItem : Item
    {
        public float healAmount;

        public override void Use(Player player)
        {
            player.Heal(healAmount);
        }
    }


}