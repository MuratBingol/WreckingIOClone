using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class AwardBase : MonoBehaviour
 {
     
     protected abstract void GiveAward(ICar car);
     [SerializeField] private GameObject _awardBox;
     [SerializeField] private ParticleSystem _particle;
     private Collider _collider;

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
     }

     private void CloseAwardBox()
     {
         _awardBox.SetActive(false);
         _particle.Play();
     }
     
     
 }

