using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Transform playerTransform;

    public float minDistanceOfObjectsToPlayer = 10f;
    
    public Transform GetLocalPlayer()
    {
        return playerTransform;
    }
    
    public void SetLocalPlayer(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }
}
