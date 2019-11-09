using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyController
{
    private float timer=0f;
    public Transform shootPoint;
    public GameObject bullet;

    private void Update() {
        if(player){
            timer += Time.deltaTime;    
            if(Vector2.Distance(transform.position, player.position) > atkRange){
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }else{
                if(timer >= atkDelay && Vector2.Distance(transform.position, player.position) <= atkRange && player.GetComponentInChildren<Health>()){
                    Vector2 shootDirection = player.position - shootPoint.position;
                    float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                    shootPoint.rotation = rotation;
                    Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                    timer = 0f;
                } 
            }
        }
    }
}
