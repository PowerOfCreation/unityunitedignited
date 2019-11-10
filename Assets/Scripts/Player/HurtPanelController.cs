// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class HurtPanelController : MonoBehaviour
{
    private Animator _Animator;

    private void Awake() {
        _Animator = GetComponent<Animator>();
    }

    public void Show() {
        _Animator.SetTrigger("isHurt");
    }
}
