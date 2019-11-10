// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool isMelee;
    public bool isBoss;

    public float detectionRange = 3f;

    public static Transform playerTransform;
    public EnemyController enemyController;

    private void Start()
    {
        playerTransform = GameManager.Instance.GetLocalPlayer();
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void Update()
    {
        if(Vector3.Distance(Player.self.transform.position, transform.position) < detectionRange)
        {
            if(isMelee)
            {
                if(isBoss)
                {
                    GetComponentInParent<Boss>().FoundPlayer();
                }
                else
                {
                    enemyController.player = playerTransform;
                }
            }
            else
            {
                enemyController.player = playerTransform;
            }
        }
        else
        {
            if(enemyController != null)
            {
                enemyController.player = null;
            }
        }
    }
}
