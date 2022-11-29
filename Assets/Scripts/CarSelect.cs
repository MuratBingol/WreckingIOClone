using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSelect : MonoBehaviour
 {
     private void Awake()
     {
        SelectCar();
     }

     private void SelectCar()
     {
         transform.GetChild(Random.Range(0,transform.childCount)).gameObject.SetActive(true);
     }
 }

