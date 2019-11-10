using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController, IStunable
{
    private float timer=0f;

    private bool frozen = false;

    private Animator animator;
    private int walkId;

    private void Start()
    {
        animator = GetComponent<Animator>();
        walkId = Animator.StringToHash("Walking");
    }

    public void Freeze()
    {
        frozen = true;
    }

    public void Unfreeze()
    {
        frozen = false;
    }

    private void Update()
    {
        if(player && !frozen)
        {
            timer += Time.deltaTime;    
            if(Vector2.Distance(transform.position, player.position) > atkRange)
            {
                animator.SetBool(walkId, true);
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                if(timer >= atkDelay && Vector2.Distance(transform.position, player.position) <= atkRange && player.GetComponentInChildren<PlayerHealth>())
                {
                    player.GetComponentInChildren<PlayerHealth>().GetDamage(damage, transform);
                    animator.SetBool(walkId, false);
                    timer = 0f;
                } 
            }
        }
        else
        {
            animator.SetBool(walkId, false);
        }
    }
}   
