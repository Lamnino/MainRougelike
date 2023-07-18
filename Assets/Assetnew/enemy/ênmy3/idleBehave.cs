using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehave : StateMachineBehaviour
{
    Transform player;
    Transform enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("character").transform;
        enemy = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) animator.SetTrigger("exit");
        if (player.position.y < enemy.position.y + 2 && player.position.y > enemy.position.y - 2)
        {
            if (player.position.x > enemy.position.x - 8 && player.position.x < enemy.position.x + 8)
            {
                if (player.position.x < enemy.position.x)
                {
                    enemy.rotation = Quaternion.Euler(0, 180, 0);
                    if (player.position.x < enemy.position.x - 3)
                    {
                        animator.Play("run");
                    }
                    else
                    {
                        animator.Play("attack");
                    }
                }
                else
                {
                    enemy.rotation = Quaternion.Euler(0, 0, 0);
                    if (player.position.x > enemy.position.x + 3)
                    {
                        animator.Play("run");
                    }
                    else
                    {
                        animator.Play("attack");
                    }
                }
            }
        }
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
