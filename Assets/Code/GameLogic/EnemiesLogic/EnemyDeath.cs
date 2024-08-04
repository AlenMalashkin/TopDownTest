using Code.Services.ScoreService;
using UnityEngine;

namespace Code.GameLogic.EnemiesLogic
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyDamageable _enemyDamageable;

        private int _scoreForKill;
        private IScoreService _scoreService;
        
        public void Init(IScoreService scoreService, int scoreForKill)
        {
            _scoreService = scoreService;
            _scoreForKill = scoreForKill;
        }
        
        private void OnEnable()
        {
            _enemyDamageable.Died += OnDied;
        }

        private void OnDisable()
        {
            _enemyDamageable.Died -= OnDied;
        }

        private void OnDied()
        {
            _scoreService.AddScore(_scoreForKill);
            Destroy(gameObject);
        }
    }
}