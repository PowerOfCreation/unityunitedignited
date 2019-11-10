using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private Transform playerTransform;

    public float minDistanceOfObjectsToPlayer = 10f;

    private int currentLevel = 0;
    private int levelCountBeforeBossLevel = 3;

    private int mainMenuId = 0;
    private int normalLevelId = 1;
    private int bossLevelId = 2;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(normalLevelId);
    }

    public void NextLevel()
    {
        currentLevel++;

        if(currentLevel == levelCountBeforeBossLevel)
        {
            SceneManager.LoadScene(bossLevelId);
        }
        else
        {
            SceneManager.LoadScene(normalLevelId);
        }
    }

    public Transform GetLocalPlayer()
    {
        return playerTransform;
    }
    
    public void SetLocalPlayer(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }
}
