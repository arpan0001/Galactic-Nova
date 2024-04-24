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
        
        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            return true;
        }

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
        laser.FireLaser(hitPosition, target);
    }

    bool FindTarget()
    {
        if(target == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");

            if(temp != null)
                target = temp.transform;
            else
                return false; // Return false if player object is not found
        }

        return true;  
    }
}
