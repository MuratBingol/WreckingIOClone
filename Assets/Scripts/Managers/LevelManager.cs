using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
 {

     [SerializeField] private GameObject _winPanel, _failPanel,_joystickPanel;
     [SerializeField] private Button _nextButton, _restartButton,_switchOn;
     [SerializeField] private AudioSource _winSound;
     private bool isCompleted;

     private void Start()
     {
        EventManager.Instance.OnFail.AddListener(Fail);
        EventManager.Instance.OnWin.AddListener(Win);
        _nextButton.onClick.AddListener(NextLevel);
        _restartButton.onClick.AddListener(Restart);
        MechanicControl();
     }


     private void Win()
     {
         if (isCompleted)
             return;
         isCompleted = true;
         _winPanel.SetActive(true);
         _winSound.Play();
     }

     private void Fail()
     {
         if (isCompleted)
             return;
         isCompleted = true;
         _failPanel.SetActive(true);
     }

     private void Restart()
     {
         _restartButton.interactable = false;
         SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
     }

     private void NextLevel()
     {
         _nextButton.interactable = false;
         SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
     }

     public void ChangeInputMechanic(int value)
     {
         PlayerPrefs.SetInt("Mechanic",value);
     }

     public void MechanicControl()
     {
         if (   PlayerPrefs.GetInt("Mechanic",0)==1)
         {
             _switchOn.gameObject.SetActive(true);
             _joystickPanel.SetActive(false);
         }
     }
 }

