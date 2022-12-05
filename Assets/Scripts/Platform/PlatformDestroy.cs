using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlatformDestroy : MonoBehaviour
 {
     private Animator _animator;
     private Rigidbody _rigidbody;
     [SerializeField] private float _waitTime;
     [SerializeField] private float _decreaseTime;


     private void Awake()
     {
         _animator = GetComponent<Animator>();
         _rigidbody = GetComponent<Rigidbody>();
         _animator.enabled = false;
     }

     private void Start()
     {
         EventManager.Instance.OnFail.AddListener(StopDestroy);
         EventManager.Instance.OnWin.AddListener(StopDestroy);
     }

     public void DisablePlatform()
     {
         StartCoroutine(ChangeColor());
     }

     IEnumerator ChangeColor()
     {
         _animator.enabled = true;
         yield return new WaitForSeconds(_waitTime);
         _animator.SetTrigger("Anim");
         Invoke(nameof(Destroy),_decreaseTime);
      
     }

     private void Destroy()
     {
         _rigidbody.isKinematic = false;
         Destroy(gameObject,2);
     }

     private void StopDestroy()
     {
         _rigidbody.isKinematic = true;
     }
     
     
 }

