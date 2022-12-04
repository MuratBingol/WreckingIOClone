using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class AIKillControl : KillControl
 {
     
     public override void Execute()
     {
         _stateControl.SetNewState(_stateControl.killState);
         AIManager.Instance.RemoveAI(GetComponent<ICar>());
     }
     
 }

