using UnityEngine;

namespace Code.GameLogic.Weapons.Bullets
{
    public class ClipBullet : Bullet
    {
        [SerializeField] private float _movementSpeed;
        
        protected override void Move(Vector3 direction)
        {
            transform.position += direction * _movementSpeed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IDamageable damageable))
                Hit(damageable);
        }
    }
}