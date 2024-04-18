using System;
using UnityEngine;

namespace TopDos.Animations
{
    public class AnimatorBrain : MonoBehaviour
    {
        private static readonly int[] Animations =
        {
            Animator.StringToHash(""),
            Animator.StringToHash("Idle"),
            Animator.StringToHash("Run"),
            Animator.StringToHash("Fall"),
            Animator.StringToHash("Death"),
            Animator.StringToHash("PistolIdle"),
            Animator.StringToHash("PistolWalk"),
            Animator.StringToHash("Shoot")
        };

        private Animator _animator;

        private EAnimation _currentAnimation;

        private Action _defaultAnimation;

        public void Initialize(EAnimation startingAnimation, Animator animator, Action DefaultAnimation)
        {
            _currentAnimation = startingAnimation;
            _animator = animator;
            _defaultAnimation = DefaultAnimation;
        }
        
        public void Play(EAnimation animation, float crossfade = 0.2f, int layer=0)
        {
            if (animation == EAnimation.NONE)
            {
                _defaultAnimation();
                return;
            }

            if (_currentAnimation == animation) return;

            _currentAnimation = animation;
            _animator.CrossFade(Animations[(int)_currentAnimation], crossfade, layer);
        }

        public EAnimation GetCurrentAnimation()
        {
            return _currentAnimation;
        }
    }
}
