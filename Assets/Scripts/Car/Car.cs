using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Car : MonoBehaviour,ICar
 {
     [SerializeField] private Rod _rod;
     [SerializeField] private CarStateControl _state;


     private void Awake()
     {
         _state = GetComponent<CarStateControl>();
     }

     private void Start()
     {
         EventManager.Instance.OnWin.AddListener(BeHappy);
     }

     public void TakeDamage(Collision collision)
     {
        _state.SetNewState(_state.crashState);
     }
     

     public void BeHappy()
     {
       _state.SetNewState(null);
     }

     public void BeSad()
     {
         
     }

     public Rod GetRod()
     {
         return _rod;
     }

     public Transform GetTransform()
     {
         return transform;
     }
 }

