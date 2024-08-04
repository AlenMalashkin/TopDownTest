using Code.GameLogic.PlayerLogic;
using Code.Infrastructure.Factories.WeaponFactory;
using Code.Services.InputService;
using Code.Services.ScoreService;
using UnityEngine;

namespace Code.Infrastructure.Factories.PlayerFactory
{
    public class PlayerFactory : IPlayerFactory
    {
        private IInputService _inputService;
        private IWeaponFactory _weaponFactory;
        private IScoreService _scoreService;

        public PlayerFactory(IInputService inputService, IWeaponFactory weaponFactory, IScoreService scoreService)
        {
            _inputService = inputService;
            _weaponFactory = weaponFactory;
            _scoreService = scoreService;
        }
        
        public Player CreatePlayer(Vector3 position)
        {
            Player playerPrefab = Resources.Load<Player>("Prefabs/Player/Player");
            Player player = Object.Instantiate(playerPrefab, position, Quaternion.identity);
            player.GetComponent<PlayerMovement>().Init(_inputService);
            player.GetComponent<PlayerShoot>().Init(_inputService);
            player.GetComponent<PlayerEquipment>().Init(_weaponFactory, _inputService);
            return player;
        }

        public PlayerCamera CreateFollowingCamera(Transform followTarget)
        {
            PlayerCamera playerCameraPrefab = Resources.Load<PlayerCamera>("Prefabs/Player/PlayerCamera");
            PlayerCamera playerCamera = Object.Instantiate(playerCameraPrefab);
            playerCamera.Follow(followTarget);
            return playerCamera;
        }
    }
}