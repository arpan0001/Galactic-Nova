using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]Asteroid asteroid;
    [SerializeField]int numberOfAsteriodsOnAnAxis = 10;
    [SerializeField]int gridSpacing = 100; 

    void Start()
     { 
       PlaceAsteroids();
     }

    void PlaceAsteroids()
    {
      for(int x = 0; x < nuumberOfAsteroidsOnAxis; x++)
      {
        for(int y = 0; y < numberOfAsteriodsOnAnAxis; y++)
        {
          for(int x = 0; x < gridSpacing; x++)
         {
            InstantiateAsteroid(x, y, z);
        }
      }
        

    }

 

  void InstantiateAsteroid(int x, int y, int z)
  {
    Instantiate(asteroid, new Vector3 ( transform.position.x + x, transform.position.y + y, transform.position.z + z),
                 Quaternion.identity,transform);
  }
 

}
