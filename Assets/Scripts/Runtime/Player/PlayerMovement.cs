using System;
using TopDos.Animations;
using TopDos.Controls;
using UnityEngine;

namespace TopDos.PlayerSpace
{
    public class PlayerMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float _rotationSpeed = 5f;

        private Player _player;
        private Animator _animator;
        private AnimatorBrain _animatorBrain;
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
            _animator ??= GetComponent<Animator>();
            _animatorBrain ??= GetComponent<AnimatorBrain>();
            _controls ??= GetComponent<ControlsHandler>();
            _playerController ??= GetComponent<CharacterController>();
        }

        private void Start()
        {
            _animatorBrain.Initialize(EAnimation.IDLE, _animator, DefaultAnimation);
        }

        public void Update()
        {
            _moveDirection = new Vector3(_controls.MoveInputDirection.x, 0, _controls.MoveInputDirection.y);

            if (_controls.JumpInputTriggered && _playerController.isGrounded)
            {
                Jump(_playerJumpForceScalar, GravityScalar);
            }

            if (_moveDirection.magnitude != 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDirection), _rotationSpeed);
            }

            CheckAnimations();
        }

        private void CheckAnimations()
        {
            if (_controls.MoveInputDirection.magnitude != 0)
            {
                _animatorBrain.Play(EAnimation.RUN);
            }
            
            else if (!_playerController.isGrounded)
            {
                _animatorBrain.Play(EAnimation.FALL);
            }

            else
            {
                _animatorBrain.Play(EAnimation.IDLE);
            }
        }

        private void DefaultAnimation()
        {
            _animatorBrain.Play(EAnimation.IDLE);
        }

        private void FixedUpdate()
        {
            Move(_moveDirection, _playerSpeed);
            GravityProccess(GravityScalar);
        }
        public void Move(Vector3 direction, float moveSpeed)
        {
            _playerController.Move(direction * (moveSpeed * Time.fixedDeltaTime));
        }

        public void Jump(float jumpForce, float gravityScalar)
        {
            _gravitySpeed += Mathf.Sqrt(jumpForce * gravityScalar);
        }

        public void GravityProccess(float gravityScalar)
        {
            _gravitySpeed += gravityScalar;
            _playerController.Move(Vector3.up * (_gravitySpeed * Time.fixedDeltaTime));
        }

    }
}
