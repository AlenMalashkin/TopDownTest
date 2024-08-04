using Code.StaticData.LevelStaticData;
using UnityEngine;

namespace Code.GameLogic.Spawners
{
    public class Spawner
    {
        private float _xSpawnRange = 8f;
        private float _zSpawnRange = 8f;
        private Vector3 _spawnPoint;

        public Spawner(LevelStaticData levelStaticData)
        {
            _xSpawnRange = levelStaticData.LevelSizeX / 2;
            _zSpawnRange = levelStaticData.LevelSizeZ / 2;
        }
        
        protected Vector3 GetRandomSpawnPointInCamera()
        {
            _spawnPoint = new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange),
                _spawnPoint.y, Random.Range(-_zSpawnRange, _zSpawnRange));

            while (IsPositionInCamera(_spawnPoint))
                _spawnPoint = new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange),
                    _spawnPoint.y, Random.Range(-_zSpawnRange, _zSpawnRange));

            return _spawnPoint;
        }

        protected Vector3 GetRandomSpawnPointOutOfCamera()
        {
            _spawnPoint = new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange),
                _spawnPoint.y, Random.Range(-_zSpawnRange, _zSpawnRange));

            while (!IsPositionInCamera(_spawnPoint))
                _spawnPoint = new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange),
                    _spawnPoint.y, Random.Range(-_zSpawnRange, _zSpawnRange));

            return _spawnPoint;
        }

        protected Vector3 GetRandomPosition()
        {
            Vector3 result = new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange), 0,
                Random.Range(-_zSpawnRange, _zSpawnRange));
            return result;
        }

        private bool IsPositionInCamera(Vector3 position)
        {
            Vector3 pointPosition = Camera.main.WorldToViewportPoint(position);
            return pointPosition.x < 0.0f || pointPosition.x > 1.0f || pointPosition.y < 0.0f || pointPosition.y > 1.0f;
        }
    }
}