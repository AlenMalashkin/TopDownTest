using Code.GameLogic.PlayerLogic;
using Code.GameLogic.Weapons;
using UnityEngine;

namespace Code.GameLogic.Pickups
{
    public class WeaponPickup : Pickup
    {
        [SerializeField] private WeaponType _type;
        
        public override void PickupItem(Collider other)
        {
            if (other.TryGetComponent(out PlayerEquipment playerEquipment))
            {
                playerEquipment.ChangeWeapon(_type);
                Destroy(gameObject);
            }
        }
    }
}