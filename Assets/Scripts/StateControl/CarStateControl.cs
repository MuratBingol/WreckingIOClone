using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class CarStateControl : MonoBehaviour
 {
     private IState state;
     public IState moveState, crashState, killState;
     public IState CurrentState
     {
         get => state;
     }

     private void Awake()
     {
         moveState = GetComponent<MovementControl>();
         crashState = GetComponent<CrashControl>();
         killState = GetComponent<MovementControl>();
         state = moveState;
     }

     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.W))
         {
            SetNewState(crashState);
         }        
         if (Input.GetKeyDown(KeyCode.S))
         {
            SetNewState(moveState);
         }
     }

     public void SetNewState(IState newstate)
     {
         state = newstate;
     }
     
     


   
 }


public enum PlayerState
{
 movement,
 crash,
 kill,
}
