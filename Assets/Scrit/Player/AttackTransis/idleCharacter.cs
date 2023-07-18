using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleCharacter : StateMachineBehaviour
{
    
    public static int StateAttack = 0;
    private bool isnext = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            Playerr.instance.isAttack = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Playerr.instance.isAttack)
        {
            Playerr.instance.isAttack = false;
            isnext = true;
            if (StateAttack == 0)
            {
                animator.Play("attack1");
            }
            else if (StateAttack == 1)
            {
                animator.Play("attack2");
            }
            else if (StateAttack == 2)
            {
                animator.Play("attack3");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isnext)
        {
            if (StateAttack == 0)
            {
                StateAttack = 1;
            }
            else if (StateAttack == 1)
            {
                StateAttack = 2;
            }
            else if (StateAttack == 2)
            {
                StateAttack = 0;
            }
            isnext = false;
        }
        else
            StateAttack = 0;
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
