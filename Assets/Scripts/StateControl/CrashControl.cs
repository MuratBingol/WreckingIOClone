using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class CrashControl : Control
 {
     
     
     
     private void Update()
     {
         if (_stateControl.CurrentState!=_state) return;
            Execute();
     }

     public override void Execute()
     {
         if ( _rigidbody.velocity.magnitude<=0.5f)
         {
             print("setNormal");
             transform.eulerAngles=Vector3.zero+Vector3.up*transform.eulerAngles.y;
             _stateControl.SetNewState(_stateControl.moveState);
         }
       
     }
 }

