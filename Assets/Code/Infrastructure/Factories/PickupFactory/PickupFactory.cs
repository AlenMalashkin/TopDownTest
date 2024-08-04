using Code.Data;
using Code.GameLogic.Pickups;
using Code.GameLogic.Weapons;
using Code.Services.StaticDataService;
using UnityEngine;

namespace Code.Infrastructure.Factories.PickupFactory
{
    public class PickupFactory : IPickupFactory
    {
        private IStaticDataService _staticDataService;
        
        public PickupFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public Pickup CreateBonusPickup(BonusType type, Vector3 position)
        {
            PickupBonusData pickupData = _staticDataService.ForPickupBonus(type);
            Pickup pickup = Object.Instantiate(pickupData.Prefab, position, Quaternion.identity);
            return pickup;
        }

        public Pickup CreateWeaponPickup(WeaponType type, Vector3 position)
        {
            PickupWeaponData pickupData = _staticDataService.ForPickupWeapon(type);
            Pickup pickup = Object.Instantiate(pickupData.Prefab, position, Quaternion.identity);
            return pickup;
        }
    }
}