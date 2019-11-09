using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController
{
    private float timer=0f;

    private void Update() {
        if(player){
            timer += Time.deltaTime;    
            if(Vector2.Distance(transform.position, player.position) > atkRange){
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }else{
                if(timer >= atkDelay && Vector2.Distance(transform.position, player.position) <= atkRange && player.GetComponentInChildren<Health>()){
                    player.GetComponentInChildren<Health>().GetDamage(damage);
                    timer = 0f;
                } 
            }
        }
    }
}   
