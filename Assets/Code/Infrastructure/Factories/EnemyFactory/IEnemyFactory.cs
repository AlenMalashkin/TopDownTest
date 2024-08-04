using Code.GameLogic.EnemiesLogic;
using UnityEngine;

namespace Code.Infrastructure.Factories.EnemyFactory
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy(Vector3 position, EnemyType type);
    }
}