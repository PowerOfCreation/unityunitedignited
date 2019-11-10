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
    public AudioClip _takeDamage;
    public GameObject deadPrefab;
    public ParticleSystem deadEffect;
    public ParticleSystem takeDamageEffect;

    private GameObject player;
    private AudioSource _AudioSource;
    private Animator animator;
    private int deathHash;

    private void Awake() {
        _AudioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        deathHash = Animator.StringToHash("Death");
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
        if (health <= 0) 
        {
            Die();
        }
        //Kockback
        rigidbody2D.AddForce((transform.position - attackerTransform.position).normalized * 500);
    }

    public virtual void Die()
    {
        animator.SetTrigger(deathHash);
    }

    public virtual void OnDeath()
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
