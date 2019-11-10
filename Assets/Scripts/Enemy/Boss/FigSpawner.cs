using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform enemy;
    public int amount = 3;
    public float spawnRate = 1f;
    private float nextSpawn = 0.0f;
    private float randX, randY;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn && amount > 0)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-17f, 15f);
            randY = Random.Range(1f, 6.5f);
            Instantiate(enemy, new Vector2(randX, randY), Quaternion.identity);
            amount--;
        }
    }
}
