using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackHolder;
   
    public float attackRadius = 1f;

    public int attackDamage = 5;

    public int attackRate = 300;

    private int attackCooldown = 0;

    public LayerMask enemyLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown--;
        
        if (Input.GetButtonDown("Jump") && attackCooldown <= 0)
        {
                PerformAttack();
        }
    }

    void PerformAttack()
    {
        Collider2D[] hits =  Physics2D.OverlapCircleAll(attackHolder.position, attackRadius, enemyLayerMask);
        foreach (Collider2D hit in hits)
        {
            IDamagable damagable = hit.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.GetDamage(attackDamage, transform);
            }
        }
        attackCooldown = attackRate;
    }
}
