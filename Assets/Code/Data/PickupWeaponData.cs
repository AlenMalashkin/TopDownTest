using System;
using Code.GameLogic.Pickups;
using Code.GameLogic.Weapons;

namespace Code.Data
{
    [Serializable]
    public class PickupWeaponData
    {
        public WeaponType Type;
        public Pickup Prefab;
    }
}