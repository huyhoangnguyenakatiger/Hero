using UnityEngine;

namespace Hero
{
    [CreateAssetMenu(fileName = "New MP Item", menuName = "Hero/Items/MP Item")]
    public class MPItem : Item
    {
        public float manaAmount;

        public override void Use(Player player)
        {
            player.RestoreMana(manaAmount);
        }
    }


}