using TopDos.Animations;
using UnityEngine;

namespace TopDos.Enemies.FSM
{
    public class EnemyAttackState : BaseState
    {
        public EnemyAttackState(Enemy enemy, AnimatorBrain animatorBrain) : base(enemy, animatorBrain)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter To Attack State");
        }

        public override void Exit()
        {
            
        }

        public override void LogicUpdate()
        {
            AnimatorBrain.Play(EAnimation.ATTACK);
        }

        public override void PhysicsUpdate()
        {
            
        }
    }
}
