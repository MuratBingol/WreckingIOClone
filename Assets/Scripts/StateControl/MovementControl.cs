using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class MovementControl : Control
 {
    
     private void FixedUpdate()
     {
         if (_stateControl.CurrentState!=_state) return;
        Execute();
     }
     
     public override void Execute()
     {
         Move();
         Rotate();
     }

     protected abstract void Move();
     protected abstract void Rotate();





 }

