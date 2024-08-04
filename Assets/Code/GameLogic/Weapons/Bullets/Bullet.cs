using System;
using UnityEngine;

namespace Code.GameLogic.Weapons.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _lifeTime;
        [SerializeField] private bool _hasDistanceLimit;

        private float _currentLifeTime;
        private Vector3 _startPosition;
        private float _damage;
        private Vector3 _direction;

        public void Init(Vector3 startPosition, float damage, Vector3 direction)
        {
            _startPosition = startPosition;
            _damage = damage;
            _direction = direction;
        }

        private void Update()
        {
            Move(_direction);
            
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime > _lifeTime || Vector3.Distance(_startPosition, transform.position) > _distance && _hasDistanceLimit)
                Destroy(gameObject);
        }

        protected abstract void Move(Vector3 direction);

        protected void Hit(IDamageable damageable)
            => damageable.TakeDamage(_damage);
    }
}