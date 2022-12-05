using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class DisableAward : MonoBehaviour
 {
     [SerializeField] private Rigidbody _parentRigidbody;
     [SerializeField] private Collider _parentCollider;

     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("FailZone"))
         {
             _parentRigidbody.isKinematic = false;
             _parentCollider.isTrigger = false;
         }
      
     }
 }

