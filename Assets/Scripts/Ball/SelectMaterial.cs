using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SelectMaterial : MonoBehaviour
 {
     [SerializeField] private List<Material> _materials;

     private void Awake()
     {
         GetComponent<MeshRenderer>().material = _materials[Random.Range(0, _materials.Count)];
     }
 }

