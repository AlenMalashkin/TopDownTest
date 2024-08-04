using Code.GameLogic.Pickups;
using Code.GameLogic.Weapons;
using UnityEngine;

namespace Code.Infrastructure.Factories.PickupFactory
{
    public interface IPickupFactory
    {
        Pickup CreateBonusPickup(BonusType type, Vector3 position);
        Pickup CreateWeaponPickup(WeaponType type, Vector3 position);
    }
}