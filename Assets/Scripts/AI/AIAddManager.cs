using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class AIAddManager : MonoBehaviour
 {
     private void Start()
     {
         AIManager.Instance.SetAI(GetComponent<ICar>());
     }
 }

