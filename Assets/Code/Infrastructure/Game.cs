using Code.GameLogic.EnemiesLogic;
using Code.GameLogic.LevelLogic;
using Code.GameLogic.Pickups;
using Code.GameLogic.PlayerLogic;
using Code.GameLogic.Spawners;
using Code.GameLogic.Weapons;
using Code.Infrastructure.Factories.LevelFactory;
using Code.Infrastructure.Factories.PlayerFactory;
using Code.Infrastructure.Factories.UIFactory;
using Code.Services.InputService;
using Code.Services.SceneLoadService;
using Code.Services.ScoreService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class Game
    {
        private ISceneLoadService _sceneLoadService;
        private ILevelFactory _levelFactory;
        private IPlayerFactory _playerFactory;
        private IInputService _inputService;
        private EnemySpawner _enemySpawner;
        private PickupSpawner _pickupSpawner;
        private ZoneSpawner _zoneSpawner;
        private IUIFactory _uiFactory;
        private IScoreService _scoreService;

        public Game(ISceneLoadService sceneLoadService, ILevelFactory levelFactory, IPlayerFactory playerFactory,
            IInputService inputService, EnemySpawner enemySpawner, PickupSpawner pickupSpawner,
            ZoneSpawner zoneSpawner, IUIFactory uiFactory, IScoreService scoreService)
        {
            _sceneLoadService = sceneLoadService;
            _levelFactory = levelFactory;
            _playerFactory = playerFactory;
            _inputService = inputService;
            _enemySpawner = enemySpawner;
            _pickupSpawner = pickupSpawner;
            _zoneSpawner = zoneSpawner;
            _uiFactory = uiFactory;
            _scoreService = scoreService;
        }

        public void StartGame()
        {
            _sceneLoadService.LoadScene("Main", OnLoad);
            _inputService.Enable();
        }

        public void EndGame()
        {
            Menu menu = new Menu(_uiFactory, _sceneLoadService, this);
            _scoreService.SaveNewMaxScoreIfPreviousBeaten();
            _enemySpawner.Reset();
            _pickupSpawner.Reset();
            menu.OpenMenu();
        }

        private void OnLoad()
        {
            Level level = _levelFactory.CreateLevel(Vector3.zero);
            Player player = _playerFactory.CreatePlayer(level.PlayerSpawnPosition);
            player.GetComponent<PlayerDeath>().Init(_scoreService, this);
            _playerFactory.CreateFollowingCamera(player.transform);
            _enemySpawner.StartSpawn(player.transform);
            _pickupSpawner.StartSpawn();
            _zoneSpawner.SpawnZones();
            Transform root = _uiFactory.CreateUIRoot();
            _uiFactory.CreateScoreViewer(root);
        }
    }
}