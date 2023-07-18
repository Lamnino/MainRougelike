using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runBehave3 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    Transform player;
    Transform enemy;
    int dir = 1;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("character").transform;
        enemy = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.Translate(new Vector2(1, 0) * 2.5f * Time.deltaTime);
        if (enemy.rotation.y == 0) dir = 1; else dir = -1;
       RaycastHit2D hit = Physics2D.Raycast(enemy.position + new Vector3(dir*0.4f, -0.5f, 0), new Vector2(dir, 0),2.5f);
       if (hit.collider != null && hit.collider.tag == "character")
       {
            animator.Play("attack");
       }
       else
        if (dir == 1 && player.position.x < enemy.position.x ||
            dir == -1 && player.position.x > enemy.position.x ||
            player.position.x < enemy.position.x - 8 && player.position.x > enemy.position.x + 8)
        {
            animator.Play("idle");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
