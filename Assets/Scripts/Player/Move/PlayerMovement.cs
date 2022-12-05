using System;
using System.Collections;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class PlayerMovement : MovementControl
    {
        
     
        [SerializeField] private float _tapDelay;
        [SerializeField] private Camera _cam;
        private Vector3 _target; 

        public override void Awake()
        {
            base.Awake();
            _inputData.direction=Vector3.zero;
            _cam=Camera.main;
        }

        private void Update()
        {
            if (TapMechanicControl())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    LookTarget();
                 
                }
                
                if (Input.GetMouseButton(0))
                {
                    _tapDelay += Time.deltaTime;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    _tapDelay = 0;
                }
            }
        }

        protected override void Move()
        {
            if (TapMechanicControl() && _tapDelay>0.5f)return;
            _rigidbody.MovePosition(transform.position+transform.forward*Time.deltaTime*_inputData.moveSpeed);
        }

        protected override void Rotate()
        {
            if (TapMechanicControl())
            {
                RotateWithTapMechanic();
                return;
            }
            Quaternion toRotate2 = Quaternion.LookRotation(_inputData.direction, Vector3.up);
            _rigidbody.rotation = Quaternion.RotateTowards(transform.rotation, toRotate2, _inputData.rotateSpeed * Time.fixedDeltaTime);
        }

        private bool TapMechanicControl()
        {
            if (PlayerPrefs.GetInt("Mechanic",0)==0)
            {
                return false;
            }

            return true;
        }

        private void RotateWithTapMechanic()
        {
            Vector3 newTarget = _target - transform.position;
            if (newTarget.magnitude<=0.3f || _target==Vector3.zero)
            {
                newTarget = transform.forward;
                _target=Vector3.zero;
            }
            Quaternion toRotate = Quaternion.LookRotation(newTarget, Vector3.up);
            if (_tapDelay>=0.5f)
            {
                toRotate = Quaternion.LookRotation(transform.right, Vector3.up);
            }
            _rigidbody.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, _inputData.tapRotateSpeed * Time.fixedDeltaTime);
           
        }

        private void LookTarget()
        {
            RaycastHit hit;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out hit)) {
                
                    _target = hit.point;
                    _target.y = transform.position.y;
                }
        }
        
        
    }
