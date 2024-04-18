using TopDos.Animations;
using UnityEngine;

public class OnFinish : StateMachineBehaviour
{
    [SerializeField] private float _crossfade;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.CrossFade("Empty", _crossfade, 1);
        
    }
}
