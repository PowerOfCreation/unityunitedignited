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

    public int iterationOffset = 8;
    public int iterationsPerLevel = 4;
    public float branchProbabilityPerLevel = .2f;
    public int enemiesPerLevel = 7;
    public int alcoholPerLevel = 9;

    private void Start()
    {
        if(GameManager.Instance != this) { Destroy(gameObject); }
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

    public void RegisterLevelGenerator(LevelGenerator levelGenerator)
    {
        if(currentLevel < levelCountBeforeBossLevel)
        {
            int levelMultiplier = currentLevel + 1;
            levelGenerator.GenerateLevel(200, 200, iterationOffset + iterationsPerLevel * levelMultiplier, branchProbabilityPerLevel * levelMultiplier, enemiesPerLevel * levelMultiplier, alcoholPerLevel * levelMultiplier);
        }
    }
}
