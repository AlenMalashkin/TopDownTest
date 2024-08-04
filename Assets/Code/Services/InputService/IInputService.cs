using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Services.InputService
{
    public interface IInputService
    {
        void Enable();
        void Disable();
        Vector2 ReadMovement();
        Vector2 ReadMousePosition();
        bool ReadShootPressed();
    }
}