using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class OnFinish : StateMachineBehaviour
{
    [SerializeField] private float _crossfade;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override async void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(stateInfo.length));
        animator.CrossFade("Empty", _crossfade, 1);
    }
}
