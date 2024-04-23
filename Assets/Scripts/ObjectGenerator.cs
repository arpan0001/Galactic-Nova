using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject pickupPrefab;
    public int initialAsteroidsCount = 50;
    public int initialPickupsCount = 10;

    private float minX = -200f;
    private float maxX = 300f;
    private float minY = -100f;
    private float maxY = 200f;
    private float minZ = -50f; // Minimum z-axis value
    private float maxZ = 50f; // Maximum z-axis value
    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        GenerateInitialObjects();
        StartCoroutine(GenerateObjects());
    }

    void GenerateInitialObjects()
    {
        for (int i = 0; i < initialAsteroidsCount; i++)
        {
            Vector3 asteroidPosition = GetRandomPosition();
            spawnedPositions.Add(asteroidPosition);
            Instantiate(asteroidPrefab, asteroidPosition, Quaternion.identity);
        }

        for (int i = 0; i < initialPickupsCount; i++)
        {
            Vector3 pickupPosition = GetRandomPosition();
            spawnedPositions.Add(pickupPosition);
            Instantiate(pickupPrefab, pickupPosition, Quaternion.identity);
        }
    }

    IEnumerator GenerateObjects()
    {
        while (true)
        {
            // Generate asteroid
            Vector3 asteroidPosition = GetRandomPosition();
            spawnedPositions.Add(asteroidPosition);
            Instantiate(asteroidPrefab, asteroidPosition, Quaternion.identity);

            // Generate pickup
            Vector3 pickupPosition = GetRandomPosition();
            spawnedPositions.Add(pickupPosition);
            Instantiate(pickupPrefab, pickupPosition, Quaternion.identity);

            yield return new WaitForSeconds(6f); // Wait for 1 second before generating next objects
        }
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
