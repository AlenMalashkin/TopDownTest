using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Services.InputService
{
    public class InputService : IInputService
    {
        private PlayerInput _playerInput;

        public InputService(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        public void Enable()
            => _playerInput.Enable();

        public void Disable()
            => _playerInput.Disable();

        public Vector2 ReadMovement()
            => _playerInput.Player.Move.ReadValue<Vector2>();

        public Vector2 ReadMousePosition()
            => _playerInput.Player.MousePosition.ReadValue<Vector2>();

        public bool ReadShootPressed()
            => _playerInput.Player.Shoot.IsPressed();
    }
}