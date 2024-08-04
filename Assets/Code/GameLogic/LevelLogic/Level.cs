using UnityEngine;

namespace Code.GameLogic.LevelLogic
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _levelTransform;
        [SerializeField] private Transform _playerSpawnPosition;

        public Vector3 PlayerSpawnPosition => _playerSpawnPosition.position;
        
        public void SetMapSize(float x, float z)
        {
            _levelTransform.localScale = new Vector3(x, 1, z);
        }
    }
}