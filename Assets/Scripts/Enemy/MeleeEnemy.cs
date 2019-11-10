using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController, IStunable
{
    private float timer=0f;

    private bool frozen = false;

    public void Freeze()
    {
        frozen = true;
    }

    public void Unfreeze()
    {
        frozen = false;
    }

    private void Update() {
        if(player && !frozen){
            timer += Time.deltaTime;    
            if(Vector2.Distance(transform.position, player.position) > atkRange){
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }else{
                if(timer >= atkDelay && Vector2.Distance(transform.position, player.position) <= atkRange && player.GetComponentInChildren<Health>()){
                    player.GetComponentInChildren<Health>().GetDamage(damage, transform);
                    timer = 0f;
                } 
            }
        }
    }
}   
