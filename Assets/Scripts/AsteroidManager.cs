using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid asteroidPrefab;
    [SerializeField] int numberOfAsteroidsOnAxis = 10;
    [SerializeField] int gridSpacing = 100;

    public List<Asteroid> asteroid = new List<Asteroid>();

    void Start()
    {
        // PlaceAsteroids();
    }

    void OnEnable()
    {
        EventManager.onStartGame += PlaceAsteroids;
        EventManager.onPlayerDeath += DestroyAsteroids;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= PlaceAsteroids;
        EventManager.onPlayerDeath -= DestroyAsteroids;
    }

    

    void PlaceAsteroids()
    {
        for (int x = 0; x < numberOfAsteroidsOnAxis; x++)
        {
            for (int y = 0; y < numberOfAsteroidsOnAxis; y++)
            {
                for (int z = 0; z < numberOfAsteroidsOnAxis; z++)
                {
                    InstantiateAsteroid(x, y, z);
                }
            }
        }
    }

    void DestroyAsteroids()
    {
      foreach(Asteroid ast in asteroid)
          ast.SelfDestruct();

          asteroid.Clear();
    }

    void InstantiateAsteroid(int x, int y, int z)
    {
        Asteroid temp =  Instantiate(asteroidPrefab, new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(), transform.position.y + (y * gridSpacing) + AsteroidOffset(), transform.position.z + (z * gridSpacing) + AsteroidOffset()),
            Quaternion.identity, transform) as Asteroid;

        asteroid.Add(temp);    
    }

    float AsteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
}
