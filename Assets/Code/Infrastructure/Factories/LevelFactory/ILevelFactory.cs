using Code.GameLogic.LevelLogic;
using UnityEngine;

namespace Code.Infrastructure.Factories.LevelFactory
{
    public interface ILevelFactory
    {
        Level CreateLevel(Vector3 position);
    }
}