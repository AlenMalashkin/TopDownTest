using System;
using Code.GameLogic.Pickups;

namespace Code.Data
{
    [Serializable]
    public class PickupBonusData
    {
        public BonusType Type;
        public Pickup Prefab;
    }
}