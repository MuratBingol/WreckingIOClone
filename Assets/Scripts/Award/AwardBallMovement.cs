using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class AwardBallMovement : MonoBehaviour
 {
     [SerializeField] private float _speed;
     [SerializeField] private Transform _player;
     [SerializeField] private Animator _animator;

     private void Awake()
     {
         _animator = GetComponent<Animator>();
         _animator.SetFloat("Speed",_speed);
     }

     private void Start()
     {
         EventManager.Instance.OnFail.AddListener(Close);
     }

     private void Close()
     {
         gameObject.SetActive(false);
     }

     private void Update()
     {
         FollowPlayer();
     }
     

  
     private void FollowPlayer()
     {
         if (_player==null)  return;
         Vector3 pos = _player.position;
         pos.y = transform.position.y;
         transform.position = pos;
     }

     public void SetPlayer(Transform player)
     {
         _player = player;
     }

 }

