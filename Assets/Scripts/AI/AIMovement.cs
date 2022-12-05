using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class AIMovement : MovementControl
 {
     [SerializeField] private Vector3 _target;


     private void Start()
     {
         SetNewTarget();
     }

 
     private void SetNewTarget()
     {
         _target = PlatformManager.Instance.CalculateNewPoint(transform.position.y);
     }
     protected override void Move()
     {
         if (Vector3.Distance(transform.position,_target)<1f) { SetNewTarget(); }
         _rigidbody.MovePosition(transform.position+transform.forward*Time.deltaTime*_inputData.moveSpeed);
     }

     protected override void Rotate()
     {
         Quaternion toRotate = Quaternion.LookRotation(_target-transform.position, Vector3.up);
         _rigidbody.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, _inputData.rotateSpeed * Time.fixedDeltaTime);
     }
 }

