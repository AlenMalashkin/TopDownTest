using UnityEngine;
using UnityEngine.AI;

namespace Code.GameLogic.EnemiesLogic
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private Transform _target;
        
        public void Init(float moveSpeed)
        {
            _agent.speed = moveSpeed;
        }

        public void SetTarget(Transform target)
            => _target = target;

        private void Update()
        {
            if (_target != null)
                _agent.SetDestination(_target.position);
        }
    }
}