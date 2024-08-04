using Code.GameLogic.Weapons.Bullets;
using Code.Infrastructure.Factories.WeaponFactory;
using Code.Services.InputService;
using UnityEngine;

namespace Code.GameLogic.Weapons
{
    public class GrenadeGun : Weapon
    {
        [SerializeField] private Bullet _bulletPrefab;
        
        private IWeaponFactory _weaponFactory;
        private IInputService _inputService;
        private Vector3 _movePosition;
        
        public void Init(IWeaponFactory weaponFactory, IInputService inputService)
        {
            _weaponFactory = weaponFactory;
            _inputService = inputService;
        }
        
        public override void Shoot()
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputService.ReadMousePosition());

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                _movePosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            
            _weaponFactory.CreateBullet(_bulletPrefab, ShootPoint, Damage, _movePosition,
                Quaternion.identity);
        }
    }
}