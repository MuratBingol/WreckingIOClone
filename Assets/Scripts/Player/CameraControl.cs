using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

 public class CameraControl : MonoBehaviour
 {
     private CinemachineVirtualCamera _virtualCamera;

     private void Awake()
     {
         _virtualCamera = GetComponent<CinemachineVirtualCamera>();
     }

     private void Start()
     {
        EventManager.Instance.OnFail.AddListener(BreakFollow);
        EventManager.Instance.OnWin.AddListener(BreakFollow);
     }

     private void BreakFollow()
     {
         _virtualCamera.m_Follow = null;
         _virtualCamera.m_LookAt = null;
     }
 }

