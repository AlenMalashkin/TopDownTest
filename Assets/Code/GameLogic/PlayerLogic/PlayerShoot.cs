using System;
using Code.Services.InputService;
using UnityEngine;

namespace Code.GameLogic.PlayerLogic
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerEquipment _playerEquipment;

        private IInputService _inputService;
        private float _shootCooldown;
        private float _shootCooldownTick;

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.ReadShootPressed())
            {
                _playerMovement.RotatePlayerInMouseDirection(_inputService.ReadMousePosition());

                if (_shootCooldownTick >= _shootCooldown)
                {
                    _playerEquipment.Weapon.Shoot();
                    _shootCooldownTick = 0f;
                }
            }
            
            _shootCooldownTick += Time.deltaTime;
        }

        public void UpdateShootCooldown()
            => _shootCooldown = 1 / _playerEquipment.Weapon.FireRate;
    }
}