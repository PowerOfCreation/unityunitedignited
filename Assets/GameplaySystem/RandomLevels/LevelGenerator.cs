using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : Singleton<LevelGenerator>
{
    public GameObject groundPrefab;
    public GameObject wallPrefab;

    public void Start()
    {
        GenerateLevel(100, 100);
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
                    GameObject.Instantiate(groundPrefab, new Vector2(x, y), Quaternion.identity, transform);
                }
                else
                {
                    GameObject.Instantiate(wallPrefab, new Vector2(x, y), Quaternion.identity, transform);
                }
            }
        } 
    }

    private void StartBranch(bool[,] groundData, Vector2Int position, Direction direction, int iterationsLeft)
    {
        if(iterationsLeft > 0)
        {
            Vector2Int endPosition = FillRoomOrHallway(groundData, position, direction);
            
            if(Random.Range(0f , 1f) > 0.5f)
            {
                Vector2Int halfPosition = position + ((endPosition - position).Divide(0.5f));

                StartBranch(groundData, halfPosition, direction.RandomlyRotateLeftOrRight(), iterationsLeft - 1);
            }

            StartBranch(groundData, endPosition, direction.RandomlyRotateLeftOrRight(), iterationsLeft - 1);
        }
    }

    private Vector2Int FillRoomOrHallway(bool[,] groundData, Vector2Int position, Direction direction)
    {
        if(Random.Range(0f, 1f) > 0.5f)
        {
            position = FillHallway(groundData, position, direction, Random.Range(3, 10));
        }
        else
        {
            position = FillRoom(groundData, position, direction, Random.Range(3, 10), Random.Range(3, 10));
        }

        return position;
    }

    private Vector2Int FillHallway(bool[,] groundData, Vector2Int position, Direction direction, int length)
    {

        Vector2Int offset = new Vector2Int(0, 0);
        try
        {
            for (int i = 0; i < length; i++)
            {
                offset = new Vector2Int(i, 0);

                offset = offset.Rotate(direction.ToQuaternion().eulerAngles.y);

                groundData[position.x + offset.x, position.y + offset.y] = true;
            }
        }
        catch(System.IndexOutOfRangeException e)
        {

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

        }

        return new Vector2Int(position.x + offset.x, position.y + offset.y);
    }
}
