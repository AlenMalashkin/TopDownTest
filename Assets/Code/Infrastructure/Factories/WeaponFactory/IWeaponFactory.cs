using Code.GameLogic.Weapons;
using Code.GameLogic.Weapons.Bullets;
using Code.Services.InputService;
using UnityEngine;

namespace Code.Infrastructure.Factories.WeaponFactory
{
    public interface IWeaponFactory
    {
        Weapon CreateWeapon(WeaponType type, Transform parent);
        Bullet CreateBullet(Bullet prefab, Transform startPosition, float damage, Vector3 direction,
            Quaternion rotation);
    }
}