using Code.Data;
using Code.GameLogic.Weapons;
using Code.GameLogic.Weapons.Bullets;
using Code.Services.StaticDataService;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace Code.Infrastructure.Factories.WeaponFactory
{
    public class WeaponFactory : IWeaponFactory
    {
        private IStaticDataService _staticDataService;
        
        public WeaponFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public Weapon CreateWeapon(WeaponType type, Transform parent)
        {
            WeaponConfig weaponConfig = _staticDataService.ForWeapon(type);
            Weapon weapon = Object.Instantiate(weaponConfig.Prefab, parent);
            weapon.Init(weaponConfig.Damage, weaponConfig.FireRate);
            return weapon;
        }

        public Bullet CreateBullet(Bullet prefab, Transform startPosition, float damage, Vector3 direction,
            Quaternion rotation)
        {
            Bullet bullet = Object.Instantiate(prefab, startPosition.position, rotation);
            bullet.Init(startPosition.position, damage, direction);
            return bullet;
        }
    }
}