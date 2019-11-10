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

    void OnTriggerEnter2D()
    {
        animator.SetTrigger(openDoorTriggerId);
    }

    public void DoorOpened()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
    }
}
