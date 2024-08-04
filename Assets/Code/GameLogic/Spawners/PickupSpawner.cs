using System;
using Code.GameLogic.Pickups;
using Code.GameLogic.Weapons;
using Code.Infrastructure.Factories.PickupFactory;
using Code.StaticData.LevelStaticData;
using UnityEngine;
using Random = System.Random;

namespace Code.GameLogic.Spawners
{
    public class PickupSpawner : Spawner, IUpdatable
    {
        private float _weaponSpawnInterval = 10f;
        private float _bonusSpawnInterval = 27f;
        
        private IPickupFactory _pickupFactory;
        private Timer _weaponSpawnTimer = new Timer();
        private Timer _bonusSpawnTimer = new Timer();

        public PickupSpawner(LevelStaticData levelStaticData, IPickupFactory pickupFactory) : base(levelStaticData)
        {
            _pickupFactory = pickupFactory;
        }

        public void StartSpawn()
        {
            _weaponSpawnTimer.StartTimer(_weaponSpawnInterval, SpawnWeaponPickup);
            _bonusSpawnTimer.StartTimer(_bonusSpawnInterval, SpawnBonusPickup);
        }

        public void Reset()
        {
            _bonusSpawnTimer.Reset();
            _weaponSpawnTimer.Reset();
        }

        public void Tick()
        {
            _weaponSpawnTimer?.Tick();
            _bonusSpawnTimer?.Tick();
        }

        private void SpawnWeaponPickup()
        {
            _pickupFactory.CreateWeaponPickup(GetRandomWeaponType(), GetRandomSpawnPointInCamera() + Vector3.up);
        }

        private void SpawnBonusPickup()
        {
            _pickupFactory.CreateBonusPickup(GetRandomBonusType(), GetRandomSpawnPointInCamera() + Vector3.up);
        }

        private BonusType GetRandomBonusType()
        {
            Array values = Enum.GetValues(typeof(BonusType));
            Random random = new Random();
            BonusType randomType = (BonusType)values.GetValue(random.Next(values.Length));
            return randomType;
        }
        
        private WeaponType GetRandomWeaponType()
        {
            Array values = Enum.GetValues(typeof(WeaponType));
            Random random = new Random();
            WeaponType randomType = (WeaponType)values.GetValue(random.Next(values.Length));

            if (randomType == WeaponType.Pistol)
                return WeaponType.Rifle;
            
            return randomType;
        }
    }
}