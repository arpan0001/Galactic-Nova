using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  [SerializeField]Transform target;
  [SerializeField]Laser laser;

   void Update()
    {
     InFront();
     HaveLineOfSight();
     if(InFront() && HaveLineOfSight())
      {
        FireLaser();
      }
    }

  bool InFront()
 {
    Vector3 directionToTarget = transform.position - target.position;
    float angle = Vector3.Angle(transform.forward, directionToTarget);
    //if in range
    if(Mathf.Abs(angle) > 90 & Mathf.Abs(angle) < 270)
    {
    //  Debug.DrawLine(transform.position, target.position, Color.green);
      return true;
    }

    //Debug.DrawLine(transform.position, target.position, Color.yellow);
    return false;
 }

 bool HaveLineOfSight()
 {
    RaycastHit hit;

    Vector3 direction = target.position - transform.position;

 //   Debug.DrawRay(laser.transform.position, direction,Color.red);

   if(Physics.Raycast(laser.transform.position,direction, out hit, laser.Distance))
   {
      
      if(hit.transform.CompareTag("Player"))
      {
        Debug.DrawRay(laser.transform.position, direction,Color.red);
        return true;
      }
   }

    return false;
 }

 void FireLaser()
 {
    Debug.Log("Fire Lasers!!!");
 }

}
