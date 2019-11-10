using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator _Anim;

    private void Start() {_Anim = GetComponent<Animator>();}

    public void FoundPlayer(){_Anim.SetTrigger("CHASING");}
}
