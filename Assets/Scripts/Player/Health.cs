// using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    public int health = 10;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private bool tookDamage = false;
    private float damageTime = .1f;

    private GameObject player;

    public virtual void GetDamage(int damage)
    {
        //Go Red When Hit
        spriteRenderer.color = new Color(1, 0, 0);
        tookDamage = true;
        //Take Damage
        health -= damage;
        if (health <= 0) 
        {
            Die();
        }
        //Kockback
        rigidbody2D.AddForce(transform.forward * 5000);

        Debug.Log("Schaden!!!");
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (tookDamage)
        {
            damageTime -= Time.deltaTime;

            if (damageTime <= 0)
            {
                spriteRenderer.color = Color.white;
                tookDamage = false;
                damageTime = .1f;
            }
        }
    }
}
