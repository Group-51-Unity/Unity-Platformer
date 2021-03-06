using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Run : StateMachineBehaviour
{
    EnemyPatrol _enemyPatrol;
    Transform Player;
    Rigidbody2D _rigidbody;
    public float attackRangeEnemy = 3f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyPatrol = animator.GetComponent<EnemyPatrol>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        animator.SetBool("onGround", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyPatrol.Patrol();
        if (Vector2.Distance(Player.position, _rigidbody.position) < attackRangeEnemy)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }




}
