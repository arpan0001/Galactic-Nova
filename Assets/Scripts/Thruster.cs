using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]

public class Thruster : MonoBehaviour
{
   
    Light thrusterLight;

   void Awake()
   {
    
     thrusterLight = GetComponent<Light>();
   }

   void Start()
   {
     
      thrusterLight.intensity = 0;
   }



    public void Intensity(float inten)
    {
      thrusterLight.intensity = inten * 2f;
    }

}
