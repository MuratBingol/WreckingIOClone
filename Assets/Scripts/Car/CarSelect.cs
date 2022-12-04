using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSelect : MonoBehaviour
{
    [SerializeField] private Transform _cars;
     private void Awake()
     {
        SelectCar();
     }

     private void SelectCar()
     {
         _cars.GetChild(Random.Range(0,transform.childCount)).gameObject.SetActive(true);
     }
 }

