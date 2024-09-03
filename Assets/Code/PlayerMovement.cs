using Code.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private float _jumpHeight = 1f;
        [SerializeField] private float _gravity = -9.81f;
        
        private IInputService _inputService;
        private Vector3 _velocity;
        private bool _isGrounded;

        private void Awake()
        {
            _inputService = new StandaloneInputService();
        }
        
        private void Update()
        {
            _isGrounded = _characterController.isGrounded;

            if (_isGrounded && _velocity.y < 0) 
                _velocity.y = 0;
            
            Vector2 axis = _inputService.Axis;
            bool isJumpPressed = _inputService.IsJumpPressed;
            
            Move(axis);
            Jump(isJumpPressed);
            Gravity();
        }
        
        private void Move(Vector2 axis)
        {
            if (axis.sqrMagnitude > Mathf.Epsilon)
            {
                Vector3 direction = new(axis.x, 0, axis.y);
                direction.Normalize();
                _characterController.Move(direction * (_movementSpeed * Time.deltaTime));
                
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
            }
        }
        
        private void Jump(bool isJumpPressed)
        {
            if (isJumpPressed && _isGrounded)
            {
                _velocity.y += Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
        }

        private void Gravity()
        {
            _velocity.y += _gravity * Time.deltaTime;
            _characterController.Move(_velocity * Time.deltaTime);
        }
    }
}