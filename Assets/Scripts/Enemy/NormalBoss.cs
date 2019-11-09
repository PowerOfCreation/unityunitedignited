using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBoss : EnemyController
{
    public float minX, minY;
    public float maxX, maxY;
    public GameObject creeps;
    // Start is called before the first frame update

    private Vector2 targetPosition;
    private Animator _Animator;

    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(maxX, maxY);
        targetPosition = new Vector2(randomX, randomY);
        // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player) return;

        if(Vector2.Distance(transform.position, targetPosition) > .5f){
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            // _Animator.SetBool("isRunning", true);
        }else{
            // _Animator.SetBool("isRunning", false);
        }
    }

    public void SummonCreeps(){
        if(!player) return;

        Instantiate(creeps, transform.position, transform.rotation);
    }
}
