using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

 public class CameraControl : MonoBehaviour
 {
   
     [SerializeField] private Transform _player;
     [SerializeField] private Vector3 _offset;
     [SerializeField] private Camera _camera;

     private void Awake()
     {
         _camera=Camera.main;;
         _offset = _camera.transform.position - _player.position;
     }

     private void Start()
     {
        EventManager.Instance.OnFail.AddListener(BreakFollow);
        EventManager.Instance.OnWin.AddListener(BreakFollow);
     }

     private void Update()
     {
         
         _camera.transform.position = _offset + _player.position;
     }

     private void BreakFollow()
     {
        Destroy(this);
     }
 }

