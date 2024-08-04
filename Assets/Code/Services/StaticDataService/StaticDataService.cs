using System.Collections.Generic;
using System.Linq;
using Code.Data;
using Code.GameLogic.EnemiesLogic;
using Code.GameLogic.Pickups;
using Code.GameLogic.Weapons;
using Code.StaticData.EnemyStaticData;
using Code.StaticData.LevelStaticData;
using Code.StaticData.PickupStaticData;
using Code.StaticData.WeaponStaticData;
using Code.StaticData.WindowStaticData;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowType, WindowData> _windows = new Dictionary<WindowType, WindowData>();
        private Dictionary<WeaponType, WeaponConfig> _weapons = new Dictionary<WeaponType, WeaponConfig>();
        private Dictionary<EnemyType, EnemyData> _enemies = new Dictionary<EnemyType, EnemyData>();
        private Dictionary<WeaponType, PickupWeaponData> _pickupWeapons = new Dictionary<WeaponType, PickupWeaponData>();
        private Dictionary<BonusType, PickupBonusData> _pickupBonuses = new Dictionary<BonusType, PickupBonusData>();
        private LevelStaticData _levelStaticData;

        public void LoadStaticData()
        {
            _levelStaticData = Resources.Load<LevelStaticData>("StaticData/Levels/LevelStaticData");

            _windows = Resources.Load<WindowStaticData>("StaticData/Windows/WindowStaticData")
                .Windows
                .ToDictionary(x => x.Type);

            _weapons = Resources.Load<WeaponStaticData>("StaticData/Weapons/WeaponStaticData")
                .Weapons
                .ToDictionary(x => x.Type);

            _enemies = Resources.Load<EnemyStaticData>("StaticData/Enemies/EnemyStaticData")
                .Enemies
                .ToDictionary(x => x.Type);

            _pickupBonuses = Resources.Load<PickupBonusStaticData>("StaticData/Pickups/PickupBonusStaticData")
                .PickupBonuses
                .ToDictionary(x => x.Type);

            _pickupWeapons = Resources.Load<PickupWeaponStaticData>("StaticData/Pickups/PickupWeaponStaticData").
                PickupWeapons
                .ToDictionary(x => x.Type);
        }

        public LevelStaticData ForLevel()
            => _levelStaticData;

        public WindowData ForWindow(WindowType type)
            => _windows[type];

        public WeaponConfig ForWeapon(WeaponType type)
            => _weapons[type];

        public EnemyData ForEnemy(EnemyType type)
            => _enemies[type];

        public PickupBonusData ForPickupBonus(BonusType type)
            => _pickupBonuses[type];

        public PickupWeaponData ForPickupWeapon(WeaponType type)
            => _pickupWeapons[type];
    }
}