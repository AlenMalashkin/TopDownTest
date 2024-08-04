using Code.GameLogic.PlayerLogic;
using UnityEngine;

namespace Code.GameLogic.Pickups
{
    public class SpeedBonus : Pickup
    {
        [SerializeField] private float _multiplier = 1.5f;
        
        public override void PickupItem(Collider other)
        {
            if (other.TryGetComponent(out PlayerEffects playerMovement))
            {
                playerMovement.ApplySpeedEffect(_multiplier);
                Destroy(gameObject);
            }
        }
    }
}