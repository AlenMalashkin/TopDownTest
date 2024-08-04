using System;
using Code.Data;
using Code.GameLogic.Spawners;
using Code.Infrastructure.Factories.EnemyFactory;
using Code.Infrastructure.Factories.LevelFactory;
using Code.Infrastructure.Factories.PickupFactory;
using Code.Infrastructure.Factories.PlayerFactory;
using Code.Infrastructure.Factories.UIFactory;
using Code.Infrastructure.Factories.WeaponFactory;
using Code.Infrastructure.Factories.ZoneFactory;
using Code.Services.InputService;
using Code.Services.ProgressService;
using Code.Services.SaveLoadService;
using Code.Services.SceneLoadService;
using Code.Services.ScoreService;
using Code.Services.StaticDataService;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        private IStaticDataService _staticDataService;
        private ISceneLoadService _sceneLoadService;
        private IUIFactory _uiFactory;
        private ILevelFactory _levelFactory;
        private IPlayerFactory _playerFactory;
        private IWeaponFactory _weaponFactory;
        private IEnemyFactory _enemyFactory;
        private IInputService _inputService;
        private IProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private IScoreService _scoreService;
        private IZoneFactory _zoneFactory;
        private IPickupFactory _pickupFactory;
        private EnemySpawner _enemySpawner;
        private PickupSpawner _pickupSpawner;
        private ZoneSpawner _zoneSpawner;

        private Game _game;
        private Menu _menu;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            RegisterServices();

            _game = new Game(_sceneLoadService, _levelFactory, _playerFactory, _inputService, _enemySpawner,
                _pickupSpawner, _zoneSpawner, _uiFactory, _scoreService);
            _menu = new Menu(_uiFactory, _sceneLoadService, _game);
            _menu.OpenMenu();
        }

        private void Update()
        {
            _enemySpawner.Tick();
            _pickupSpawner.Tick();
        }

        private void RegisterServices()
        {
            _progressService = new ProgressService();
            _saveLoadService = new SaveLoadService(_progressService);
            _scoreService = new ScoreService(_progressService, _saveLoadService);
            _progressService.Progress = _saveLoadService.LoadProgress() ?? new Progress();
            _staticDataService = new StaticDataService();
            _staticDataService.LoadStaticData();
            _inputService = new InputService(new PlayerInput());
            _uiFactory = new UIFactory(_staticDataService, _scoreService);
            _sceneLoadService = new SceneLoadService(this);
            _levelFactory = new LevelFactory(_staticDataService);
            _weaponFactory = new WeaponFactory(_staticDataService);
            _playerFactory = new PlayerFactory(_inputService, _weaponFactory, _scoreService);
            _enemyFactory = new EnemyFactory(_staticDataService, _scoreService);
            _zoneFactory = new ZoneFactory();
            _pickupFactory = new PickupFactory(_staticDataService);
            _enemySpawner = new EnemySpawner(_staticDataService.ForLevel(), _enemyFactory);
            _pickupSpawner = new PickupSpawner(_staticDataService.ForLevel(), _pickupFactory);
            _zoneSpawner = new ZoneSpawner(_staticDataService.ForLevel(), _zoneFactory);
        }
    }
}