using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerKillControl : KillControl
 {
     public override void Execute()
     {
         _stateControl.SetNewState(_state);
         EventManager.Instance.OnFail?.Invoke();
     }
 }

