using TopDos.Animations;
using UnityEngine;
using TopDos.PlayerSpace;

namespace TopDos.Enemies.FSM
{
    public class EnemyChasingState : BaseState
    {
        public EnemyChasingState(Enemy enemy, AnimatorBrain animator) : base(enemy, animator)
        {

        }

        public override void Enter()
        {
            Debug.Log("Enter to Chasing");
        }

        public override void Exit()
        {
            
        }

        public override void LogicUpdate()
        {
            ChasePlayer(Enemy.Player);
            AnimatorBrain.Play(EAnimation.RUN);
        }

        public override void PhysicsUpdate()
        {
            
        }

        private void ChasePlayer(Player player)
        {
            Enemy.Agent.SetDestination(player.transform.position);
        }
    }
}
