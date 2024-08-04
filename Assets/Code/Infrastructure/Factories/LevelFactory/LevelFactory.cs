using Code.GameLogic.LevelLogic;
using Code.Services.StaticDataService;
using Code.StaticData.LevelStaticData;
using UnityEngine;

namespace Code.Infrastructure.Factories.LevelFactory
{
    public class LevelFactory : ILevelFactory
    {
        private IStaticDataService _staticDataService;

        public LevelFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public Level CreateLevel(Vector3 position)
        {
            LevelStaticData levelStaticData = _staticDataService.ForLevel();
            Level level = Object.Instantiate(levelStaticData.LevelPrefab, position, Quaternion.identity);
            level.SetMapSize(levelStaticData.LevelSizeX, levelStaticData.LevelSizeZ);
            return level;
        }
    }
}