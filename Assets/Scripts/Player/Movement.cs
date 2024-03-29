﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 5;
    public Transform playerSprite;
    public Animator animator;
    private Rigidbody2D rigidbody2d;
    private AudioSource _AudioSource;
    public AudioClip dashSound;

    int walkId;

    private float dashSpeed = 50f;
    private float dashCooldown = 10f;
    private float startDashTime = 0f;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        walkId = Animator.StringToHash("walking");
        _AudioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector2 moveDirection = rigidbody2d.velocity;

        if(moveHorizontal == 0 && moveVertical == 0){
            _AudioSource.Pause();
        }else{
            _AudioSource.UnPause();
        }
        animator.SetBool(walkId, moveVertical != 0 || moveHorizontal != 0);

        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            playerSprite.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        rigidbody2d.AddForce(movement * speed * Time.deltaTime);

        if (Time.time > startDashTime + dashCooldown)
        {
            if (Input.GetButtonDown("Shift"))
            {
                if(dashSound) _AudioSource.PlayOneShot(dashSound, .3f);
                startDashTime = Time.time;
                rigidbody2d.velocity = playerSprite.up * dashSpeed;
            }
        }
    }
}
