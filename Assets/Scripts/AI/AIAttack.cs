using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class AIAttack : Control
 {
     private List<ICar> _cars = new List<ICar>();
     [SerializeField] private float _attackSpeed;
     private Coroutine _attackCoroutine;
  
     private void OnTriggerEnter(Collider other)
     {
         ICar car = other.GetComponent<ICar>();
         if (car!=null && !_cars.Contains(car))
         {
             _cars.Add(car);
             if (_attackCoroutine==null)
             {
                 _stateControl.SetNewState(this);
                 _attackCoroutine = StartCoroutine(Attack());
             }
         }
     }

     IEnumerator  Attack()
     {
         while (_cars.Count>0)
         {
             Execute();
             yield return null;
         }
         _stateControl.SetNewState(_stateControl.moveState);
         StopCoroutine(_attackCoroutine);
         _attackCoroutine = null;
     }

     private void OnTriggerExit(Collider other)
     {
         ICar car = other.GetComponent<ICar>();
         if (car!=null && _cars.Contains(car))
         {
             _cars.Remove(car);
         }
     }
     
     
     public override void Execute()
     {
         if (_stateControl.CurrentState==this)
         {
             Quaternion toRotate = Quaternion.LookRotation(transform.right, Vector3.up);
             _rigidbody.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, _attackSpeed * Time.fixedDeltaTime);
         }
     }

     
     
 }

