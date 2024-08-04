using Code.GameLogic.EnemiesLogic;
using Code.Infrastructure.Factories.EnemyFactory;
using Code.StaticData.LevelStaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Code.GameLogic.Spawners
{
    public class EnemySpawner : Spawner, IUpdatable
    {
        private float _secondsToDecreaseSpawnInterval;
        private float _spawnTimeDecreaseInterval = 10f;
        private float _startSpawnInterval = 2f;
        private float _spawnIntervalDecrease = 0.1f;
        private float _minSpawnInterval = 0.5f;

        private float _currentSpawnInterval = 2f;
        private IEnemyFactory _enemyFactory;
        private Transform _target;
        private Timer _spawnTimer = new Timer();
        private Timer _spawnTimeDecreaseTimer = new Timer();

        public EnemySpawner(LevelStaticData levelStaticData, IEnemyFactory enemyFactory) : base(levelStaticData)
        {
            _enemyFactory = enemyFactory;
        }

        public void StartSpawn(Transform target)
        {
            _spawnTimer.StartTimer(_currentSpawnInterval, SpawnEnemy);
            _spawnTimeDecreaseTimer.StartTimer(_spawnTimeDecreaseInterval, DecreaseSpawnInterval);
            _target = target;
        }

        public void Reset()
        {
            _spawnTimer.Reset();
            _spawnTimeDecreaseTimer.Reset();
            _currentSpawnInterval = 2f;
        }

        public void Tick()
        {
            _spawnTimer?.Tick();
            _spawnTimeDecreaseTimer?.Tick();
        }

        private void DecreaseSpawnInterval()
        {
            if (_currentSpawnInterval > _minSpawnInterval)
                _currentSpawnInterval = Mathf.Max(_minSpawnInterval, _currentSpawnInterval - _spawnIntervalDecrease);

            _spawnTimeDecreaseTimer.StartTimer(_currentSpawnInterval, DecreaseSpawnInterval);
        }

        private void SpawnEnemy()
        {
            Vector3 spawnPosition = GetRandomSpawnPointOutOfCamera();
            if (NavMesh.SamplePosition(spawnPosition, out NavMeshHit hit, 2f, NavMesh.AllAreas))
                _enemyFactory.CreateEnemy(hit.position, GetRandomEnemyType())
                    .GetComponent<EnemyMovement>()
                    .SetTarget(_target);
            else
                SpawnEnemy();

            _spawnTimer.StartTimer(_currentSpawnInterval, SpawnEnemy);
        }

        private EnemyType GetRandomEnemyType()
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(0, 100);

            if (randomNumber > 90)
                return EnemyType.Armored;

            if (randomNumber > 70)
                return EnemyType.Nimble;

            return EnemyType.Common;
        }
    }
}