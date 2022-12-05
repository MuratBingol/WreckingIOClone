using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class WaterKillControl : MonoBehaviour
 {
     [SerializeField] private GameObject _particle;
     [SerializeField] private AudioSource _waterSound;


     private void OnTriggerEnter(Collider other)
     {
         ICar car = other.GetComponent<ICar>();

         if (car!=null)
         {
             ShowParticle(other.ClosestPoint(car.GetTransform().position));
             car.GetTransform().gameObject.SetActive(false);
         }
     }

     private void ShowParticle(Vector3 closestPos)
     {
         _waterSound.Play();
         GameObject particle = Instantiate(_particle, closestPos, Quaternion.identity);
         particle.transform.SetParent(transform);
         Vector3 pos = particle.transform.localPosition;
         pos.y = 1f;
         particle.transform.localPosition = pos;
     }
     
 }

