using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public float minDistanceOfObjectsToPlayer = 10f;

    private static int currentLevel = 0;
    private static int levelCountBeforeBossLevel = 3;

    private static int mainMenuId = 0;
    private static int configLevelId = 1;
    private static int normalLevelId = 2;
    private static int bossLevelId = 3;

    public int iterationOffset = 8;
    public int iterationsPerLevel = 4;
    public float branchProbabilityPerLevel = .2f;
    public int enemiesPerLevel = 7;
    public int alcoholPerLevel = 9;

    private static bool isConfigured = false;

    public void LoadConfig()
    {
        if(!isConfigured)
        {
            isConfigured = true;
            SceneManager.LoadScene(configLevelId);
        }
        else
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(normalLevelId);
    }

    public static void NextLevel()
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

    public void RegisterLevelGenerator(LevelGenerator levelGenerator)
    {
        if(currentLevel < levelCountBeforeBossLevel)
        {
            int levelMultiplier = currentLevel + 1;
            levelGenerator.GenerateLevel(200, 200, iterationOffset + iterationsPerLevel * levelMultiplier, branchProbabilityPerLevel * levelMultiplier, enemiesPerLevel * levelMultiplier, alcoholPerLevel * levelMultiplier);
        }
    }
}
