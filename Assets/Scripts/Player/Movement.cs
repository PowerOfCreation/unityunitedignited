using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 5;
    public Transform playerSprite;
    public Animator animator;
    private Rigidbody2D rigidbody2d;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;

    int walkId;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        walkId = Animator.StringToHash("walking");
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector2 moveDirection = rigidbody2d.velocity;

        animator.SetBool(walkId, moveVertical != 0 || moveHorizontal != 0);

        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            playerSprite.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        
        rigidbody2d.AddForce(movement * speed * Time.deltaTime);

        if (dashTime < 0)
        {
            dashTime = startDashTime;
            rigidbody2d.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;
            if (Input.GetButtonDown("Shift") && moveDirection.x > 0)
            {
                rigidbody2d.velocity = Vector2.right * dashSpeed;
            }
            else if (Input.GetButtonDown("Shift") && moveDirection.x < 0)
            {
                rigidbody2d.velocity = Vector2.left * dashSpeed;
            }
            else if (Input.GetButtonDown("Shift") && moveDirection.y > 0)
            {
                rigidbody2d.velocity = Vector2.up * dashSpeed;
            }
            else if (Input.GetButtonDown("Shift") && moveDirection.y < 0)
            {
                rigidbody2d.velocity = Vector2.up * dashSpeed;
            }
        }
    }
}
