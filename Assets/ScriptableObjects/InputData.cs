using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InputData",menuName = "ScriptableObjects/Datas/InputData")]
 public class InputData : ScriptableObject
 {
     public float moveSpeed;
     public float rotateSpeed;
     public float tapRotateSpeed;
     public Vector3 direction;
 }

