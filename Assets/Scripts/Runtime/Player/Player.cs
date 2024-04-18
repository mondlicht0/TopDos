using TopDos.Animations;
using TopDos.Player.Data;
using UnityEngine;
using Zenject;

namespace TopDos.Player
{
    public class Player : MonoBehaviour
    {
        private CharacterController _characterController;
        private IMovement _playerMovement;
        private Animator _animator;
        private AnimatorBrain _animatorBrain;
        [field: SerializeField] public PlayerData Data { get; private set; }


        private void Awake()
        {
            _playerMovement ??= GetComponent<IMovement>();
            _characterController ??= GetComponent<CharacterController>();
            _animator ??= GetComponent<Animator>();
            _animatorBrain ??= GetComponent<AnimatorBrain>();
        }
    }
}
