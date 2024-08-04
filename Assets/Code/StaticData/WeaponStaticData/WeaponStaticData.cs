using System.Collections.Generic;
using Code.Data;
using UnityEngine;

namespace Code.StaticData.WeaponStaticData
{
    [CreateAssetMenu(fileName = "WeaponStaticData", menuName = "Weapons", order = 2)]
    public class WeaponStaticData : ScriptableObject
    {
        [SerializeField] private List<WeaponConfig> _weapons;
        public List<WeaponConfig> Weapons => _weapons;
    }
}