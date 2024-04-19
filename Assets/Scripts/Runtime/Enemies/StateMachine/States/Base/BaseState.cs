using TopDos.Animations;
using UnityEngine;

namespace TopDos.Enemies.FSM
{
    public abstract class BaseState : IState
    {
        protected Enemy Enemy;
        protected AnimatorBrain AnimatorBrain;
        protected BaseState _currentState;

        protected BaseState(Enemy enemy, AnimatorBrain animatorBrain) 
        {
            Enemy = enemy;
            AnimatorBrain = animatorBrain;
        }
        public abstract void Enter();

        public abstract void LogicUpdate();

        public abstract void PhysicsUpdate();

        public abstract void Exit();
    }
}
