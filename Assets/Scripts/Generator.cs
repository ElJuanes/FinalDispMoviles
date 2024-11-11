using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 3f;
    public int poolSize = 10;
    private float[] yPositions = { -4f, -3f, -2f };
    private List<GameObject> obstaclePool;
    private int currentIndex = 0;
    private int generationCount = 0; 
    void Start()
    {
        obstaclePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(obstaclePrefab);
            obj.SetActive(false);
            obstaclePool.Add(obj);
        }

        InvokeRepeating(nameof(SpawnObstacle), spawnInterval, spawnInterval);
    }

    void SpawnObstacle()
    {
        generationCount++; 

        if (generationCount % 5 == 0)
        {
            GenerateObstacle();
            GenerateObstacle();
        }
        else
        {
            GenerateObstacle();
        }
    }

    void GenerateObstacle()
    {
        int randomIndex = Random.Range(0, yPositions.Length);
        Vector3 spawnPosition = new Vector3(10f, yPositions[randomIndex], 0f);

        GameObject obstacle = obstaclePool[currentIndex];
        obstacle.transform.position = spawnPosition;
        obstacle.SetActive(true);

        currentIndex = (currentIndex + 1) % poolSize;
    }
}
