using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

 public abstract class Control:MonoBehaviour,IState
 {
     protected Rigidbody _rigidbody;
     protected CarStateControl _stateControl;
     protected IState _state;


     public virtual void Awake()
     {
         _rigidbody = GetComponent<Rigidbody>();
         _stateControl = GetComponent<CarStateControl>();
         _state = this;
     }
     public abstract void Execute();

   
 }

