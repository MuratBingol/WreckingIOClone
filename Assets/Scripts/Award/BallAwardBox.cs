using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallAwardBox : AwardBase
 {
     [SerializeField] private AwardBallMovement ballMovementAward;
     [SerializeField] private float _awardDelay;
     private Rod _carRod;


     private void Start()
     {
         Invoke(nameof(GiveBox),Random.Range(6,12));
     }

     protected override void GiveAward(ICar car)
     {
         _carRod = car.GetRod();
         _carRod.CloseRod();
         ballMovementAward.SetPlayer(car.GetTransform());
         ballMovementAward.transform.SetParent(null);
         ballMovementAward.transform.gameObject.SetActive(true);
         Invoke(nameof(AwardEnd),_awardDelay);
         
     }

     private void AwardEnd()
     {
         ballMovementAward.gameObject.SetActive(false);
         _carRod.OpenRod();
     }

     private void GiveBox()
     {
         _collider.enabled = true;
         _awardBox.SetActive(true);
         transform.position = PlatformManager.Instance.CalculateNewPoint(transform.position.y);
     }
 }

