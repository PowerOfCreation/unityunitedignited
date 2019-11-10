using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    public int health = 10;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private bool tookDamage = false;
    private float damageTime = .1f;
    public AudioClip takeDamage;
    public GameObject deadPrefab;
    public ParticleSystem deadEffect;
    public ParticleSystem takeDamageEffect;

    private GameObject player;
    private AudioSource _AudioSource;

    private void Awake() {
        _AudioSource = GetComponent<AudioSource>();
    }

    public virtual void GetDamage(int damage, Transform attackerTransform)
    {
        foreach (IStunable stuneable in GetComponentsInChildren<IStunable>())
        {
            stuneable.Freeze();
        }

        spriteRenderer.color = Color.red;
        tookDamage = true;
        health -= damage;
        if(takeDamageEffect) takeDamageEffect.Play();
        if(takeDamage) {
            _AudioSource.PlayOneShot(takeDamage, 0.5F);
        }
        if (health <= 0) 
        {
            Die();
        }
        //Kockback
        rigidbody2D.AddForce((transform.position - attackerTransform.position).normalized * 500);
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
                foreach (IStunable stuneable in GetComponentsInChildren<IStunable>())
                {
                    stuneable.Unfreeze();
                }
                spriteRenderer.color = Color.white;
                tookDamage = false;
                damageTime = .1f;
            }
        }
    }
}
