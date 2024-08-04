using Code.GameLogic.PlayerLogic;
using UnityEngine;

namespace Code.GameLogic.Pickups
{
    public class ImmortalBonus : Pickup
    {
        public override void PickupItem(Collider other)
        {
            if (other.TryGetComponent(out PlayerEffects playerEffects))
            {
                playerEffects.ApplyImmortality();
                Destroy(gameObject);
            }
        }
    }
}