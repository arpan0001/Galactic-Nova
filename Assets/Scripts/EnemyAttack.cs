using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Laser laser;

    private Vector3 hitPosition;

    void Update()
    {
        if(!FindTarget())
            return;
            
        if (InFront() && HaveLineOfSightRayCast())
        {
            FireLaser();
        }
    }

    bool InFront()
    {
        Vector3 directionToTarget = target.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);
        //if in range
        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            //  Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
        }

        //Debug.DrawLine(transform.position, target.position, Color.yellow);
        return false;
    }

    bool HaveLineOfSightRayCast()
    {
        RaycastHit hit;

        Vector3 direction = target.position - transform.position;

        Debug.DrawRay(transform.position, direction, Color.red);

        if (Physics.Raycast(transform.position, direction, out hit, laser.Distance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position, direction, Color.green);
                hitPosition = hit.point;
                return true;
            }
        }

        return false;
    }

    void FireLaser()
    {
       // Debug.Log("Fire Lasers!!!");
        laser.FireLaser(hitPosition, target);
    }

     bool FindTarget()
    {
      if(target == null)
        target = GameObject.FindGameObjectWithTag("Player").transform;

      if(target == null)
        return false;

        return true;  
    
    }
}
