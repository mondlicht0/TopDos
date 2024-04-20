using System;
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
        private Health _health;
        private Animator _animator;
        private AnimatorBrain _animatorBrain;
        private EnemyStateMachine _fsm;

        public bool IsDead { get; private set; }
        public Player Player { get; private set; }
        public Collider PlayerCollider { get; private set; }
        public NavMeshAgent Agent { get; private set; }

        private void Awake()
        {
            _animator ??= GetComponentInChildren<Animator>();
            _animatorBrain ??= GetComponent<AnimatorBrain>();
            _health ??= GetComponent<EnemyHealth>();
            Agent ??= GetComponent<NavMeshAgent>();
            Player ??= FindObjectOfType<Player>();
            PlayerCollider ??= Player.GetComponentInChildren<Collider>();
            
            _animatorBrain.Initialize(EAnimation.IDLE, _animator, DefaultAnimation);
            InitStateMachine();
        }

        private void Start()
        {
            _health.OnDied += PlayDeathAnimation;
            _health.OnDied += SetIsDead;
        }

        private void Update()
        {
            if (!IsDead)
            {
                _fsm.UpdateFSM();
            }
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

        private void SetIsDead()
        {
            IsDead = true;
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

        private void PlayDeathAnimation()
        {
            //_animatorBrain.Play(EAnimation.DEATH);
            gameObject.SetActive(false);
        }
    }
}
