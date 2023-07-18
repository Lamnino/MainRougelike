using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transis3 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Playerattack.instance.at3r.SetActive(true);
        Playerr.instance.Attacking = true;
        if (Playerr.instance.transform.rotation == Quaternion.Euler(0, -180, 0))
            Playerattack.instance.at3r.GetComponent<DamnAttack>().dir = -1;
        else Playerattack.instance.at3r.GetComponent<DamnAttack>().dir = 1;
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            Playerr.instance.isAttack = false;
            Playerr.instance.Attacking = false;
        Playerattack.instance.at3r.SetActive(false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
