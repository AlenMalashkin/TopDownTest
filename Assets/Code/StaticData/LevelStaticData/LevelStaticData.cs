using Code.GameLogic.LevelLogic;
using UnityEngine;

namespace Code.StaticData.LevelStaticData
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName = "Level", order = 0)]
    public class LevelStaticData : ScriptableObject
    {
        [SerializeField] private Level _levelPrefab;
        [SerializeField] private Vector3 _playerPosition;
        [SerializeField] private int _levelSizeX;
        [SerializeField] private int _levelSizeZ;
        public Level LevelPrefab => _levelPrefab;
        public Vector3 PlayerPosition => _playerPosition;
        public int LevelSizeX => _levelSizeX;
        public int LevelSizeZ => _levelSizeZ;
    }
}