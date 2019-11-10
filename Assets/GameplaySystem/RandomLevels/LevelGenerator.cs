using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : Singleton<LevelGenerator>
{
    public List<GameObject> groundPrefabs = new List<GameObject>();
    public GameObject enemyPrefab;
    public GameObject alcoholPrefab;
    public GameObject wallPrefab;
    public GameObject exitLevelPrefab;

    public void Start()
    {
        GenerateLevel(200, 200);
    }

    private void GenerateLevel(int width, int height)
    {
        bool[,] groundData = new  bool[width, height];

        int startPositionX = width / 2;
        int startPositionY = height / 2;

        Vector2Int lastPosition = StartBranch(groundData, new Vector2Int(startPositionX, startPositionY), new Direction(), 16);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(groundData[x, y] == true)
                {
                    GameObject.Instantiate(GetGroundPrefab(), new Vector2(x, y), Quaternion.identity, transform);
                }
                else
                {
                    GameObject.Instantiate(wallPrefab, new Vector2(x, y), Quaternion.identity, transform);
                }
            }
        }

        SpawnGameObjectOnGround(groundData, 10, enemyPrefab);
        SpawnGameObjectOnGround(groundData, 10, alcoholPrefab);

        GameObject.Instantiate(exitLevelPrefab, new Vector3(lastPosition.x, lastPosition.y, -1), Quaternion.identity);

        GetComponent<CompositeCollider2D>().GenerateGeometry();
    }

    private void SpawnGameObjectOnGround(bool[,] groundData, int amount, GameObject gameObjectToSpawn)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2Int position = GetRandomGroundPositionAwayFromPoint(groundData, GameManager.Instance.GetLocalPlayer().position, GameManager.Instance.minDistanceOfObjectsToPlayer);
            GameObject.Instantiate(gameObjectToSpawn, new Vector3(position.x, position.y, -1), Quaternion.identity);
        }
    }

    private static Vector2Int GetRandomGroundPositionAwayFromPoint(bool[,] groundData, Vector2 point, float minDistanceToPoint)
    {
        while(true)
        {
            int posX = Random.Range(0, groundData.GetLength(0));
            int posY = Random.Range(0, groundData.GetLength(1));
            
            Vector2Int pointToTest = new Vector2Int(posX, posY);
            
            if(groundData[posX, posY] && Vector2.Distance(pointToTest, point) > minDistanceToPoint)
            {
                return pointToTest;
            }
        }
    }

    private GameObject GetGroundPrefab()
    {
        return groundPrefabs[Random.Range(0, groundPrefabs.Count)];
    }

    private Vector2Int StartBranch(bool[,] groundData, Vector2Int position, Direction direction, int iterationsLeft)
    {
        Vector2Int endPosition = position;

        if(iterationsLeft > 0)
        {
            endPosition = FillRoomOrHallway(groundData, position, direction);
            
            if(Random.Range(0f , 1f) >= 0.5f)
            {
                Vector2Int halfPosition = position + ((endPosition - position).Divide(2f));

                StartBranch(groundData, halfPosition, direction.RandomlyRotateLeftOrRightAndCreateNewDirection(), iterationsLeft - 1);
            }

            endPosition = StartBranch(groundData, endPosition, direction.RandomlyRotateLeftOrRightAndCreateNewDirection(), iterationsLeft - 1);
        }

        return endPosition;
    }

    private static Vector2Int FillRoomOrHallway(bool[,] groundData, Vector2Int position, Direction direction)
    {
        Vector2Int endPosition;

        if(Random.Range(0f, 1f) > 0.5f)
        {
            endPosition = FillHallway(groundData, position, direction, Random.Range(3, 10));
        }
        else
        {
            endPosition = FillRoom(groundData, position, direction, Random.Range(3, 10), Random.Range(3, 10));
        }

        return endPosition;
    }

    private static Vector2Int FillHallway(bool[,] groundData, Vector2Int position, Direction direction, int length, int width = 3)
    {

        Vector2Int offset = new Vector2Int(0, 0);
        try
        {
            for (int y = 0; y < width; y++)
            {
                for (int i = 0; i < length; i++)
                {
                    offset = new Vector2Int(i, y);

                    offset = offset.Rotate(direction.ToQuaternion().eulerAngles.y);

                    groundData[position.x + offset.x, position.y + offset.y] = true;
                }
            }
        }
        catch(System.IndexOutOfRangeException e)
        {
            offset = new Vector2Int(0, 0);
        }

        return new Vector2Int(position.x + offset.x, position.y + offset.y); 
    }

    private static Vector2Int FillRoom(bool[,] groundData, Vector2Int position, Direction direction, int width, int height)
    {
        Vector2Int offset = new Vector2Int(0, 0);

        try
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    offset = new Vector2Int(x, y);

                    groundData[position.x + offset.x, position.y + offset.y] = true;
                }   
            }
        }
        catch(System.IndexOutOfRangeException e)
        {
            offset = new Vector2Int(0, 0);
        }

        return new Vector2Int(position.x + offset.x, position.y + offset.y);
    }
}
