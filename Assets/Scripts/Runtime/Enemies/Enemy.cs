using TopDos.Animations;
using TopDos.Enemies.FSM;
using UnityEngine;
using UnityEngine.AI;
using TopDos.PlayerSpace;
using FuncPredicate = TopDos.Enemies.FSM.FuncPredicate;

namespace TopDos.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _data;
        private Animator _animator;
        private AnimatorBrain _animatorBrain;
        private EnemyStateMachine _fsm;

        public Player Player { get; private set; }
        public Collider PlayerCollider { get; private set; }
        public NavMeshAgent Agent { get; private set; }
        public bool IsAttacking { get; private set; }

        private void Awake()
        {
            _animator ??= GetComponentInChildren<Animator>();
            _animatorBrain ??= GetComponent<AnimatorBrain>();
            Agent ??= GetComponent<NavMeshAgent>();
            Player ??= FindObjectOfType<Player>();
            PlayerCollider ??= Player.GetComponentInChildren<Collider>();
            
            _animatorBrain.Initialize(EAnimation.IDLE, _animator, DefaultAnimation);
            InitStateMachine();
        }

        private void Update()
        {
            _fsm.UpdateFSM();
        }

        private void InitStateMachine()
        {
            _fsm = new EnemyStateMachine();
            
            EnemyChasingState chasingState = new EnemyChasingState(this, _animatorBrain);
            EnemyAttackState attackState = new EnemyAttackState(this, _animatorBrain);
            
            _fsm.AddTransition(attackState, chasingState, new FuncPredicate(() => IsChasingPlayer()));
            _fsm.AddTransition(chasingState, attackState, new FuncPredicate(() => IsAttack()));
            _fsm.SetState(chasingState);
        }
        
        private void DefaultAnimation()
        {
            _animatorBrain.Play(EAnimation.RUN);
        }

        private bool IsChasingPlayer()
        {
            return Vector3.Distance(transform.position, Player.transform.position) > _data.AttackRange;
        }

        private bool IsAttack()
        {
            return Vector3.Distance(transform.position, Player.transform.position) < _data.AttackRange;
        }
    }
}
