using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class AIManager : Singleton<AIManager>
 {
     private List<ICar> Cars = new List<ICar>();


     public void SetAI(ICar car)
     {
         Cars.Add(car);
     }

     public void RemoveAI(ICar car)
     {
         if (Cars.Contains(car))
         {
             Cars.Remove(car);
             AICountControl();
         } 
     }

     public void AICountControl()
     {
         if (Cars.Count==0)
         {
             EventManager.Instance.OnWin?.Invoke();
         }
     }
 }

