using System;
using Code.GameLogic.EnemiesLogic;

namespace Code.Data
{
    [Serializable]
    public class EnemyData
    {
        public EnemyType Type;
        public Enemy EnemyPrefab;
        public float Health;
        public float MoveSpeed;
        public int ScoreForKill;
    }
}