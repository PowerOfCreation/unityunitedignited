using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    public GameObject[] patrolPoints;
    public float patrolSpeed = 5f;
    private int randomIdx;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       patrolPoints = GameObject.FindGameObjectsWithTag("BPatrols");
       randomIdx = Random.Range(0, patrolPoints.Length);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrolPoints[randomIdx].transform.position, patrolSpeed * Time.deltaTime);

       if(Vector2.Distance(animator.transform.position, patrolPoints[randomIdx].transform.position) < 0.1f){
           randomIdx = Random.Range(0, patrolPoints.Length);
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
