using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Singleton <T>: MonoBehaviour where T: Component
 {
     public static T Instance { get; private set; }
     [SerializeField] private bool isDontDestroyOnLoad;

     protected virtual void Awake()
     {
         
         if (Instance==null){ Instance = this as T;}

         if (Instance != this)
         {
             Destroy(Instance);
             Instance = this as T;
         }

         if (isDontDestroyOnLoad) { DontDestroyOnLoad(this); }

     }
 }

