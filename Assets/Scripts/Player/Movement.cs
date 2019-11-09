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

    int walkId;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        walkId = Animator.StringToHash("walking");
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector2 moveDirection = gameObject.GetComponent<Rigidbody2D>().velocity;

        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            playerSprite.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            animator.SetBool(walkId, true);
        }
        else
        {
            animator.SetBool(walkId, false);
        }
        rigidbody2d.AddForce(movement * speed * Time.deltaTime);
    }
}
