using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class AwardBase : MonoBehaviour
 {
     
     protected abstract void GiveAward(ICar car);
     [SerializeField] protected GameObject _awardBox;
     [SerializeField] private ParticleSystem _particle;
     protected Collider _collider;

     private void Awake()
     {
         _collider = GetComponent<Collider>();
     }

     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Player"))
         {
             _collider.enabled = false;
             ICar car = other.GetComponent<ICar>();
             GiveAward(car);
             CloseAwardBox();
         }

         if (other.CompareTag("FailZone"))
         {
             gameObject.SetActive(false);
         }
     }

     private void CloseAwardBox()
     {
         _awardBox.SetActive(false);
         _particle.Play();
     }
     
     
 }

