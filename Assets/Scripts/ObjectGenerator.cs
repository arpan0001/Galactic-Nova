using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab1;
    public GameObject asteroidPrefab2;
    public GameObject pickupPrefab1;
    public GameObject pickupPrefab2;
    public GameObject enemyPrefab; // New enemy prefab
    public int initialAsteroidsCount = 5;
    public int initialPickupsCount = 3;
    public float objectDestroyDelay = 5f; // Delay before destroying objects
    public float enemyGenerationDelay = 5f; // Delay before generating new enemies

    private float minX = -500f;
    private float maxX = 500f;
    private float minY = -300f;
    private float maxY = 300f;
    private float minZ = -500f;
    private float maxZ = 500f;
    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        GenerateInitialObjects();
        StartCoroutine(GenerateObjects());
        StartCoroutine(GenerateEnemies());
    }

    void GenerateInitialObjects()
    {
        for (int i = 0; i < initialAsteroidsCount; i++)
        {
            Vector3 asteroidPosition = GetRandomPosition();
            spawnedPositions.Add(asteroidPosition);
            GameObject asteroid = Instantiate(i % 2 == 0 ? asteroidPrefab1 : asteroidPrefab2, asteroidPosition, Quaternion.identity);
            StartCoroutine(DestroyObject(asteroid)); // Start coroutine to destroy the asteroid
        }

        for (int i = 0; i < initialPickupsCount; i++)
        {
            Vector3 pickupPosition = GetRandomPosition();
            spawnedPositions.Add(pickupPosition);
            GameObject pickup = Instantiate(i % 2 == 0 ? pickupPrefab1 : pickupPrefab2, pickupPosition, Quaternion.identity);
            StartCoroutine(DestroyObject(pickup)); // Start coroutine to destroy the pickup
        }
    }

    IEnumerator GenerateObjects()
    {
        while (true)
        {
            // Generate asteroid
            Vector3 asteroidPosition = GetRandomPosition();
            spawnedPositions.Add(asteroidPosition);
            GameObject asteroid = Instantiate(Random.Range(0, 2) == 0 ? asteroidPrefab1 : asteroidPrefab2, asteroidPosition, Quaternion.identity);
            StartCoroutine(DestroyObject(asteroid)); // Start coroutine to destroy the asteroid

            // Generate pickup
            Vector3 pickupPosition = GetRandomPosition();
            spawnedPositions.Add(pickupPosition);
            GameObject pickup = Instantiate(Random.Range(0, 2) == 0 ? pickupPrefab1 : pickupPrefab2, pickupPosition, Quaternion.identity);
            StartCoroutine(DestroyObject(pickup)); // Start coroutine to destroy the pickup

            yield return new WaitForSeconds(1f); // Wait for 1 second before generating next objects
        }
    }

    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            // Generate enemy
            Vector3 enemyPosition = GetRandomPosition();
            spawnedPositions.Add(enemyPosition);
            GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
            StartCoroutine(DestroyObject(enemy)); // Start coroutine to destroy the enemy

            yield return new WaitForSeconds(enemyGenerationDelay); // Wait for enemyGenerationDelay seconds before generating next enemy
        }
    }

    IEnumerator DestroyObject(GameObject obj)
    {
        yield return new WaitForSeconds(objectDestroyDelay);
        Destroy(obj);
    }

    Vector3 GetRandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        while (!IsPositionValid(position))
        {
            position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        }
        return position;
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 spawnedPosition in spawnedPositions)
        {
            if (Vector3.Distance(position, spawnedPosition) < 5f)
            {
                return false;
            }
        }
        return true;
    }
}
