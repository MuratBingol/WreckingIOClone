using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class BallAward : DamageBase
 {
     [SerializeField] protected float _power;
     
     protected override void Damage(ICar car, Collision collision)
     {
         car.TakeDamage(collision);
         collision.rigidbody.AddExplosionForce(_power,transform.position,50,3);
     }
 }

