using TopDos.Controls;
using UnityEngine;

namespace TopDos.Player
{
    public class PlayerMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float _rotationSpeed = 5f;

        private Player _player;
        private ControlsHandler _controls;
        private CharacterController _playerController;

        private Vector3 _moveDirection;
        private float _playerJumpForceScalar => _player.Data.JumpForceScalar;
        private float _playerSpeed => _player.Data.JumpForceScalar;
        private float _gravitySpeed;

        private const float GravityScalar = -9.81f;

        private void Awake()
        {
            _player ??= GetComponent<Player>();
            _controls ??= GetComponent<ControlsHandler>();
            _playerController ??= GetComponent<CharacterController>();
        }

        public void Update()
        {
            _moveDirection = new Vector3(_controls.MoveInputDirection.x, 0, _controls.MoveInputDirection.y);

            if (_controls.JumpInputTriggered && _playerController.isGrounded)
            {
                Jump(_playerJumpForceScalar, GravityScalar);
            }

            if (_moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDirection), _rotationSpeed);
            }
        }

        public void FixedUpdate()
        {
            Move(_moveDirection, _playerSpeed);
            GravityProccess(GravityScalar);
        }
        public void Move(Vector3 direction, float moveSpeed)
        {
            _playerController.Move(moveSpeed * direction * Time.fixedDeltaTime);
        }

        public void Jump(float jumpForce, float gravityScalar)
        {
            _gravitySpeed += Mathf.Sqrt(jumpForce * gravityScalar);
        }

        public void GravityProccess(float gravityScalar)
        {
            _gravitySpeed += gravityScalar;
            _playerController.Move(Vector3.up * _gravitySpeed * Time.fixedDeltaTime);
        }

    }
}
