using System;
using Code.GameLogic.Weapons;
using UnityEngine;

namespace Code.Data
{
    [Serializable]
    public class WeaponConfig
    {
        public WeaponType Type;
        public Weapon Prefab;
        public float Damage;
        public float FireRate;
    }
}