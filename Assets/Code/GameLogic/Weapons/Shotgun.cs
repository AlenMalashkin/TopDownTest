using Code.GameLogic.Weapons.Bullets;
using Code.Infrastructure.Factories.WeaponFactory;
using UnityEngine;

namespace Code.GameLogic.Weapons
{
    public class Shotgun : Weapon
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _spread = 10;
        [SerializeField] private int _bulletsCount = 5;

        private IWeaponFactory _weaponFactory;

        public void Init(IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }

        public override void Shoot()
        {
            for (int i = 0; i < _bulletsCount; i++)
            {
                _weaponFactory.CreateBullet(_bulletPrefab, ShootPoint, Damage, transform.forward,
                    Quaternion.Euler(0, Random.Range(-_spread, _spread), 0) * transform.rotation);
            }
        }
    }
}