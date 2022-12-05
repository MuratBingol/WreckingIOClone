using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class WinParticle : MonoBehaviour
 {
     [SerializeField] private GameObject _particle;

     private void Start()
     {
         EventManager.Instance.OnWin.AddListener(OpenParticle);
     }

     private void OpenParticle()
     {
         _particle.SetActive(true);
     }
 }

