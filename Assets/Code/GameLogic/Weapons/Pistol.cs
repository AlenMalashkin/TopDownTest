using Code.GameLogic.Weapons.Bullets;
using Code.Infrastructure.Factories.WeaponFactory;
using UnityEngine;

namespace Code.GameLogic.Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private Bullet _bulletPrefab;

        private float _shootCooldown;
        private IWeaponFactory _weaponFactory;
        
        public void Init(IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }
        
        public override void Shoot()
        {
            _weaponFactory.CreateBullet(_bulletPrefab, ShootPoint, Damage, transform.forward, Quaternion.identity);
        }
    }
}