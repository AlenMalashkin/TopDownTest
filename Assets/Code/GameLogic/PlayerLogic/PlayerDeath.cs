using Code.GameLogic.EnemiesLogic;
using Code.Infrastructure;
using Code.Services.ScoreService;
using UnityEngine;

namespace Code.GameLogic.PlayerLogic
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerEffects _playerEffects;
        
        private IScoreService _scoreService;
        private Game _game;

        public void Init(IScoreService scoreService, Game game)
        {
            _scoreService = scoreService;
            _game = game;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Enemy enemy) && !_playerEffects.Immortal)
                Die();
        }

        public void Die()
        {
            _game.EndGame();
            _scoreService.Reset();
        }
    }
}