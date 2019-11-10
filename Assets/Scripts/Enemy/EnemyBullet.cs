using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject _Player;
    private Vector2 targetPosition;
    public float speed = 10f;
    public int damage = 2;

    private void Start() {
        _Player = GameObject.FindGameObjectWithTag("Player");
        targetPosition = _Player.transform.position;
    }

    private void Update() {
        if(_Player){
            if(Vector2.Distance(transform.position, targetPosition) > .5f){
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }else{
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            _Player.GetComponentInChildren<PlayerHealth>().GetDamage(damage, transform);
        }
    }
}
