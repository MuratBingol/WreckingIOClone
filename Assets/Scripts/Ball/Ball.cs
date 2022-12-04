using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Ball : DamageBase
 {
     private Collider _collider;
     private MeshRenderer _renderer;

     protected override void Awake()
     {
         base.Awake();
         _collider = GetComponent<Collider>();
         _renderer = GetComponent<MeshRenderer>();
     }
     
     protected override void Damage(ICar car,Collision collision)
     {
        car.TakeDamage(collision);
     }

     public void CloseBall()
     {
         _collider.enabled = false;
         _renderer.enabled = false;
     }

     public void OpenBall()
     {
         _collider.enabled = true;
         _renderer.enabled = true;
     }
 }

