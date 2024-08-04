using UnityEngine;

namespace Code.GameLogic.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        private float _damage;
        private float _fireRate;
        
        public Transform ShootPoint => _shootPoint;
        public float Damage => _damage;
        public float FireRate => _fireRate;

        public void Init(float damage, float fireRate)
        {
            _damage = damage;
            _fireRate = fireRate;
        }

        public abstract void Shoot();
    }
}