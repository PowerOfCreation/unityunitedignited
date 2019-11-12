// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool isMelee;
    public bool isBoss;

    public float detectionRange = 3f;

    public EnemyController enemyController;

    private void Start()
    {
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
                    enemyController.player = Player.self.transform;
                }
            }
            else
            {
                enemyController.player = Player.self.transform;
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
