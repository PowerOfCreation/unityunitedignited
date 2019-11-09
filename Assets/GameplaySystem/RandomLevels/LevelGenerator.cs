using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : Singleton<LevelGenerator>
{
    public List<GameObject> groundPrefabs = new List<GameObject>();
    public GameObject wallPrefab;

    public void Start()
    {
        GenerateLevel(200, 200);
    }

    public void GenerateLevel(int width, int height)
    {
        bool[,] groundData = new  bool[width, height];

        int startPositionX = width / 2;
        int startPositionY = height / 2;

        StartBranch(groundData, new Vector2Int(startPositionX, startPositionY), new Direction(), 16);

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

        GetComponent<CompositeCollider2D>().GenerateGeometry();
    }

    private GameObject GetGroundPrefab()
    {
        return groundPrefabs[Random.Range(0, groundPrefabs.Count)];
    }

    private void StartBranch(bool[,] groundData, Vector2Int position, Direction direction, int iterationsLeft)
    {
        if(iterationsLeft > 0)
        {
            Vector2Int endPosition = FillRoomOrHallway(groundData, position, direction);
            
            if(Random.Range(0f , 1f) >= 0.5f)
            {
                Vector2Int halfPosition = position + ((endPosition - position).Divide(2f));

                StartBranch(groundData, halfPosition, direction.RandomlyRotateLeftOrRightAndCreateNewDirection(), iterationsLeft - 1);
            }

            StartBranch(groundData, endPosition, direction.RandomlyRotateLeftOrRightAndCreateNewDirection(), iterationsLeft - 1);
        }
    }

    private Vector2Int FillRoomOrHallway(bool[,] groundData, Vector2Int position, Direction direction)
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

    private Vector2Int FillHallway(bool[,] groundData, Vector2Int position, Direction direction, int length, int width = 3)
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

    private Vector2Int FillRoom(bool[,] groundData, Vector2Int position, Direction direction, int width, int height)
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
