using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class KillControl : Control
 {
     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("FailZone"))
         {
             Execute();
         }
     }

   
 }

