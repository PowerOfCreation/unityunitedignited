using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackHolder;
   
    public float attackRadius = 1f;

    public int attackDamage = 5;

    private bool canAttack = true;

    public LayerMask enemyLayerMask;

    private Animator animator;
    private int attackTriggerId;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        attackTriggerId = Animator.StringToHash("attack");
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && canAttack)
        {
                PerformAttack();
        }
    }

    void PerformAttack()
    {
        canAttack = false;
        animator.SetTrigger(attackTriggerId);

        Collider2D[] hits =  Physics2D.OverlapCircleAll(attackHolder.position, attackRadius, enemyLayerMask);
        
        foreach (Collider2D hit in hits)
        {
            IDamagable damagable = hit.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.GetDamage(attackDamage, transform);
            }
        }
    }

    public void OnAttackEnded()
    {
        canAttack = true;
    }
}
