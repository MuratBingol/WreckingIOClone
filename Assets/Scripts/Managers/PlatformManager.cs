using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformManager : Singleton<PlatformManager>
 {
     private float localScale;
     private Coroutine _coroutine;
     private PlatformDestroy _platformDestroy;
     
     [SerializeField] private float _decreasePercent;
     [SerializeField] private GameObject _paltformPrefab;
     [SerializeField] private GameObject _winParticle;
     [SerializeField] private float _waitTime;
     

     protected override void Awake()
     {
         base.Awake();
         SetLocalScale();
     }

     private void Start()
     {
        StartDecrease();
        EventManager.Instance.OnFail.AddListener(StopDecrease);
        EventManager.Instance.OnWin.AddListener(StopDecrease);
     }

     private void SetLocalScale()
     {
         _platformDestroy = transform.GetChild(0).GetComponent<PlatformDestroy>();
         localScale = (_platformDestroy.transform.localScale.x/2)-3;
     }


     public Vector3 CalculateNewPoint(float y)
     {
         Vector3 newPoint = Random.insideUnitSphere * localScale;
         newPoint.y = y;
         return newPoint;
     }

     public void StartDecrease()
     {
         _coroutine = StartCoroutine(DecreasePlace());
     }

     private void StopDecrease()
     {
         StopCoroutine(_coroutine);
     }
     

     IEnumerator DecreasePlace()
     {
         float timeFLag = _waitTime;
         while (timeFLag>0)
         {
             timeFLag -= Time.deltaTime;
             yield return null;
         }
         _platformDestroy.DisablePlatform();
         Vector3 pos = _platformDestroy.transform.position;
         _platformDestroy.transform.localPosition-=Vector3.up*0.01f;
         GameObject newPlatform =Instantiate(_paltformPrefab, pos, Quaternion.identity,transform);
         newPlatform.transform.SetSiblingIndex(0);
         newPlatform.transform.localScale = new Vector3(localScale*2 * _decreasePercent, 1, localScale*2 * _decreasePercent);
         SetLocalScale();
         StartDecrease();
     }
     
 }

