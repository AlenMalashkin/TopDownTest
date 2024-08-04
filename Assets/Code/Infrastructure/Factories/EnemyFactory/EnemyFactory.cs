using Code.Data;
using Code.GameLogic.EnemiesLogic;
using Code.Services.ScoreService;
using Code.Services.StaticDataService;
using UnityEngine;

namespace Code.Infrastructure.Factories.EnemyFactory
{
    public class EnemyFactory : IEnemyFactory
    {
        private IStaticDataService _staticDataService;
        private IScoreService _scoreService;

        public EnemyFactory(IStaticDataService staticDataService, IScoreService scoreService)
        {
            _staticDataService = staticDataService;
            _scoreService = scoreService;
        }
        
        public Enemy CreateEnemy(Vector3 position, EnemyType type)
        {
            EnemyData enemyData = _staticDataService.ForEnemy(type);
            Enemy enemy = Object.Instantiate(enemyData.EnemyPrefab, position, Quaternion.identity);
            enemy.GetComponent<EnemyDamageable>().Init(enemyData.Health);
            enemy.GetComponent<EnemyMovement>().Init(enemyData.MoveSpeed);
            enemy.GetComponent<EnemyDeath>().Init(_scoreService, enemyData.ScoreForKill);
            return enemy;
        }
    }
}