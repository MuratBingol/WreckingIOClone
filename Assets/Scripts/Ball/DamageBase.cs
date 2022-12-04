using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class DamageBase : MonoBehaviour
 {

     protected Rigidbody _rigidbody;
     
     protected virtual void Awake()
     {
         _rigidbody = GetComponent<Rigidbody>();
        
     }

     private void OnCollisionEnter(Collision collision)
     {
         ICar car = collision.collider.GetComponent<ICar>();
         if (car!=null)
         {
             Damage(car,collision);
             // collision.rigidbody.AddExplosionForce(_power,transform.position,20,20);
             // collision.rigidbody.AddForce(Vector3.up*_rigidbody.velocity.magnitude);
         }
     }

     protected abstract void Damage(ICar car,Collision collision);

 }

