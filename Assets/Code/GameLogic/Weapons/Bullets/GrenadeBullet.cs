using UnityEngine;

namespace Code.GameLogic.Weapons.Bullets
{
    public class GrenadeBullet : Bullet
    {
        [SerializeField] private float _spread = 0.1f;
        
        protected override void Move(Vector3 direction)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, 0.05f);

            if (Vector3.Distance(transform.position, direction) < _spread)
            {
                Destroy(gameObject);
            }
        }
    }
}