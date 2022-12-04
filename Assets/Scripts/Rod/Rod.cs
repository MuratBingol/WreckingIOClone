using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Rod : MonoBehaviour
 {
     private Transform _parent;
     [SerializeField] private MeshRenderer rodRender;
     [SerializeField] private Ball _ball;

     private void Awake()
     {
         _parent = transform.parent;
     }

     private void Start()
     {
         transform.SetParent(SolverManager.Instance.transform);
         _parent.gameObject.SetActive(false);
     }

     public void CloseRod()
     {
         _ball.CloseBall();
         rodRender.enabled = false;
     }

     public void OpenRod()
     {
         _ball.OpenBall();
         rodRender.enabled = true;
     }
 }

