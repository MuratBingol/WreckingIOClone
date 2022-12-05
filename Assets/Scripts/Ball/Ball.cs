using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Ball : DamageBase
 {
     private Collider _collider;
     private MeshRenderer _renderer;
     [SerializeField] private AudioSource _hitSound;

     protected override void Awake()
     {
         base.Awake();
         _collider = GetComponent<Collider>();
         _renderer = GetComponent<MeshRenderer>();
     }
     
     protected override void Damage(ICar car,Collision collision)
     {
        car.TakeDamage(collision);
        _hitSound.Stop();
        _hitSound.Play();
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

