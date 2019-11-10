using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private Animator animator;
    private int openDoorTriggerId;

    void Start()
    {
        animator = GetComponent<Animator>();
        openDoorTriggerId = Animator.StringToHash("Open");
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            animator.SetTrigger(openDoorTriggerId);
        }
    }

    public void DoorOpened()
    {
        GameManager.Instance.NextLevel();
    }
}
