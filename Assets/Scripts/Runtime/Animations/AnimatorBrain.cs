using System;
using UnityEngine;

namespace TopDos.Player.Animations
{
    public class AnimatorBrain : MonoBehaviour
    {
        private readonly static int[] _animations =
        {
            Animator.StringToHash("Idle"),
            Animator.StringToHash("Walk"),
            Animator.StringToHash("Fall"),
            Animator.StringToHash("PistolIdle"),
            Animator.StringToHash("PistolWalk"),
            Animator.StringToHash("PistolShoot"),
            Animator.StringToHash("Death"),
        };

        private Animator _animator;
        private Animations[] _currentAnimation;
        private bool[] _layerLocked;

        private Action<int> DefaultAnimation;
    }

    public enum Animations
    {
        IDLE,
        WALK,
        FALL,
        DEATH,
        PISTOLIDLE,
        PISTOLWALK,
        PISTOLSHOOT,
    }
}
