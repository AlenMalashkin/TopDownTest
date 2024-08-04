using System;
using Code.Services.InputService;
using UnityEngine;

namespace Code.GameLogic.PlayerLogic
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed = 4;
        [SerializeField] private float _speedMultiplier = 1;
        [SerializeField] private float _rotationSpeed = 180f;

        private IInputService _inputService;
        private Vector3 _moveDirection;

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Update()
        {
            _moveDirection = new Vector3(_inputService.ReadMovement().x, 0, _inputService.ReadMovement().y);
            ClampPlayerPosition();
        }

        private void Move()
        {
            _rigidbody.velocity = _moveDirection * _speed * _speedMultiplier;
        }

        private void ClampPlayerPosition()
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9, 9),
                transform.position.y, Mathf.Clamp(transform.position.z, -9, 9));
        }

        public void RotatePlayerInMouseDirection(Vector2 inputMousePosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(inputMousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 mousePosition = ray.GetPoint(distance);
                Vector3 direction = (mousePosition - transform.position).normalized;
                direction.y = 0;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation =
                    Quaternion.RotateTowards(transform.rotation, 
                        targetRotation, 
                        _rotationSpeed * Time.deltaTime);
            }
        }

        public void AddSpeedMultiplier(float speedMultiplier)
            => _speedMultiplier = speedMultiplier;
    }
}