using System.Collections.Generic;
using Code.Data;
using UnityEngine;

namespace Code.StaticData.PickupStaticData
{
    [CreateAssetMenu(fileName = "PickupWeaponStaticData", menuName = "PickupWeapon", order = 4)]
    public class PickupWeaponStaticData : ScriptableObject
    {
        [SerializeField] private List<PickupWeaponData> _pickupWeapons;
        public List<PickupWeaponData> PickupWeapons => _pickupWeapons;
    }
}