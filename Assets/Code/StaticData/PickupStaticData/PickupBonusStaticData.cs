using System.Collections.Generic;
using Code.Data;
using UnityEngine;

namespace Code.StaticData.PickupStaticData
{
    [CreateAssetMenu(fileName = "PickupBonusStaticData", menuName = "PickupBonus", order = 4)]
    public class PickupBonusStaticData : ScriptableObject
    {
        [SerializeField] private List<PickupBonusData> _pickupBonuses;
        public List<PickupBonusData> PickupBonuses => _pickupBonuses;
    }
}