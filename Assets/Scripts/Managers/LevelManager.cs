using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class LevelManager : MonoBehaviour
 {

     [SerializeField] private GameObject _winPanel, _failPanel;

     private void Start()
     {
        EventManager.Instance.OnFail.AddListener(Fail);
        EventManager.Instance.OnWin.AddListener(Win);
     }


     private void Win()
     {
         _winPanel.SetActive(true);
     }

     private void Fail()
     {
         _failPanel.SetActive(true);
     }

     private void Restart()
     {
         
     }

     private void NextLevel()
     {
         
     }
 }

