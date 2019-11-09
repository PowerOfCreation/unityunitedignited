using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController
{
    public float attackRange;
    private float timer=0f;
    

    private void Update() {
        timer += Time.deltaTime;
        if(!player) return;

        if(Vector2.Distance(transform.position, player.position) > attackRange){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }else{
            if(timer >= atkDelay && Vector2.Distance(transform.position, player.position) <= attackRange){
                //Give damage to player
                Debug.Log("Enemy Attack");
                timer = 0f;
            }
        }

    }
}   
