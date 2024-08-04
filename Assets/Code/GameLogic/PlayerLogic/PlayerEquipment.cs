using Code.GameLogic.Weapons;
using Code.Infrastructure.Factories.WeaponFactory;
using Code.Services.InputService;
using UnityEngine;

namespace Code.GameLogic.PlayerLogic
{
    public class PlayerEquipment : MonoBehaviour
    {
        [SerializeField] private WeaponType _weaponByDefault;
        [SerializeField] private Transform _weaponSpawnPoint;
        [SerializeField] private PlayerShoot _playerShoot;

        private Weapon _weapon;
        private WeaponType _currentWeapon;
        private IWeaponFactory _weaponFactory;
        private IInputService _inputService;

        public Weapon Weapon => _weapon;
        public WeaponType CurrentWeapon => _currentWeapon;

        public void Init(IWeaponFactory weaponFactory, IInputService inputService)
        {
            _weaponFactory = weaponFactory;
            _inputService = inputService;
        }

        private void Start()
        {
            ChangeWeapon(_weaponByDefault);
        }

        public void ChangeWeapon(WeaponType type)
        {
            if (_weapon != null)
                Destroy(_weapon.gameObject);

            _weapon = _weaponFactory.CreateWeapon(type, _weaponSpawnPoint);
            AdditionalWeaponInitialize(_weapon);
            _currentWeapon = type;
            _playerShoot.UpdateShootCooldown();
        }

        private void AdditionalWeaponInitialize(Weapon weapon)
        {
            if (weapon is Pistol pistol)
                pistol.Init(_weaponFactory);
            else if (weapon is Rifle rifle)
                rifle.Init(_weaponFactory);
            else if (weapon is Shotgun shotgun)
                shotgun.Init(_weaponFactory);
            else if (weapon is GrenadeGun grenadeGun)
                grenadeGun.Init(_weaponFactory, _inputService);
        }
    }
}