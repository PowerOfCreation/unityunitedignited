using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateMachineBehaviour
{
    private GameObject _Player;
    private Health _PlayerHealth;
    public float chaseSpeed;
    public float atkRange = 0.5f;
    public float summonDelay = 3f;
    public int damage = 5;
    public GameObject[] enemyPrefab;
    private float timer;
    private float stimer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _PlayerHealth = _Player.GetComponentInChildren<Health>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(_Player && _PlayerHealth){
            timer+=Time.deltaTime;
            stimer+=Time.deltaTime;
            if(Vector2.Distance(animator.transform.position, _Player.transform.position) > atkRange){
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, _Player.transform.position, chaseSpeed * Time.deltaTime);
            }else{
                _PlayerHealth.GetDamage(damage, null);
                timer=0f;
            }
            if(stimer > summonDelay){
                stimer = 0f;
                for (int i = 0; i < enemyPrefab.Length; i++)
                {
                    Instantiate(enemyPrefab[i], animator.transform.position, animator.transform.rotation);
                }
            }
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
