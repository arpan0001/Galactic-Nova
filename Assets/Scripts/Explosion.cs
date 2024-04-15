using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]GameObject explosion;
    [SerializeField]Rigidbody rigidBody;
    [SerializeField]Shield shield;
    [SerializeField]float laserHitModifier = 100f;

   void IveBeenHit(Vector3 pos)
   {
      GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as  GameObject;
      Destroy(go,6f);
      
      
      if(shield == null)
         return;

      Debug.Log("Taking Damage");   
      shield.TakeDamage();   
   }

   void OnCollisionEnter(Collision collision)
   {
     foreach(ContactPoint contact in collision.contacts)
         IveBeenHit(contact.point);
   }

   public void AddForce(Vector3 hitPosition, Transform hitSource)
   {
     IveBeenHit(hitPosition);
     if(rigidBody == null)
        return;

        Vector3 forceVector = hitSource.position - transform.position;
        Debug.Log(forceVector * laserHitModifier);
        rigidBody.AddForceAtPosition(forceVector* laserHitModifier, hitPosition, ForceMode.Impulse);
   }
}

