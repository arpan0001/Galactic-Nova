using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject pickupPrefab;

    private float minX = -5f;
    private float maxX = 5f;
    private float minY = -5f;
    private float maxY = 5f;

    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects()
    {
        while (true)
        {
            // Generate asteroid
            Vector3 asteroidPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
            Instantiate(asteroidPrefab, asteroidPosition, Quaternion.identity);

            // Generate pickup
            Vector3 pickupPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
            Instantiate(pickupPrefab, pickupPosition, Quaternion.identity);

            yield return new WaitForSeconds(2f); // Wait for 2 seconds before generating next objects
        }
    }
}
