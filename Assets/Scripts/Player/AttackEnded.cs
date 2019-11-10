using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnded : MonoBehaviour
{
    Attack attack;

    private void Start()
    {
        attack = GetComponentInParent<Attack>();
    }

    public void OnAttackEnded()
    {
        attack.OnAttackEnded();
    }
}
