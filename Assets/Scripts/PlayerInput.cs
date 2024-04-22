using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]Laser[] laser;

    void Update ()
   {
         if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Laser l in laser)
            { 
               
               l.FireLaser();
            }
        } 
    }

}
