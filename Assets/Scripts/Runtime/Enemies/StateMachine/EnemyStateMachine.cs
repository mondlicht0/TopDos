using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDos.Enemies.FSM
{
    public class EnemyStateMachine : MonoBehaviour
    {
        private StateNode _currentState;

        private Dictionary<Type, StateNode> _nodes = new Dictionary<Type, StateNode>();
        
        private HashSet<ITransition> _transitions = new HashSet<ITransition>();

        public void UpdateFSM()
        {
            var transition = GetTransition();
            if (transition != null)
            {
                ChangeState(transition.TargetState);
            }

            _currentState.State?.LogicUpdate();
        }
        
        public void FixedUpdateFSM()
        {
            _currentState.State?.PhysicsUpdate();
        }

        private void ChangeState(IState state)
        {
            if (state == _currentState) return;

            var previousState = _currentState.State;
            var newState = _nodes[state.GetType()].State;

            previousState.Exit();
            newState.Enter();

            _currentState = _nodes[state.GetType()];
        }
        public void SetState(IState state)
        {
            _currentState = _nodes[state.GetType()];
            _currentState.State.Enter();
        }
        
        private ITransition GetTransition()
        {
            foreach (var transition in _transitions)
            {
                if (transition.Condition.Evaluate())
                {
                    return transition;
                }
            }

            foreach (var transition in _currentState.Transitions)
            {
                if (transition.Condition.Evaluate())
                {
                    return transition;
                }
            }

            return null;
        }

        public void AddTransition(IState from, IState to, IPredicate condition)
        {
            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }
        
        private StateNode GetOrAddNode(IState state)
        {
            var node = _nodes.GetValueOrDefault(state.GetType());

            if (node == null)
            {
                node = new StateNode(state);
                _nodes.Add(state.GetType(), node);
            }

            return node;
        }

        private class StateNode
        {
            public IState State { get; }
            public HashSet<ITransition> Transitions { get; }

            public StateNode(IState state)
            {
                State = state;
                Transitions = new HashSet<ITransition>();
            }
            public void AddTransition(IState state, IPredicate predicate)
            {
                Transitions.Add(new Transition(state, predicate));
            }
        }
    }
}
