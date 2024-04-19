using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDos.Animations
{
    public class AnimatorBrain : MonoBehaviour
    {
        [SerializeField] private List<string> _animationStatesList = new List<string>();
        private List<int> _animations = new List<int>();
        private Animator _animator;
        private Action _defaultAnimation;
        EAnimation _currentAnimation;

        public void Initialize(EAnimation startingAnimation, Animator animator, Action DefaultAnimation)
        {
            _currentAnimation = startingAnimation;
            _animator = animator;
            _defaultAnimation = DefaultAnimation;

            foreach (var animation in _animationStatesList)
            {
                //_animations.Append(Animator.StringToHash(animation));
                _animations.Add(Animator.StringToHash(animation));
            }
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
            _animator.CrossFade(_animations[(int)_currentAnimation], crossfade, layer);
        }

        public EAnimation GetCurrentAnimation()
        {
            return _currentAnimation;
        }
    }
}
