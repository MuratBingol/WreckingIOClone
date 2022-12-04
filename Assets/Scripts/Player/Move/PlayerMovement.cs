using UnityEngine;


    public class PlayerMovement : MovementControl
    {
        
        [SerializeField] private InputData _inputData;
        
        protected override void Move()
        {
            _rigidbody.MovePosition(transform.position+transform.forward*Time.deltaTime*_inputData.moveSpeed);
        }

        protected override void Rotate()
        {
            Quaternion toRotate = Quaternion.LookRotation(_inputData.direction, Vector3.up);
            _rigidbody.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, _inputData.rotateSpeed * Time.fixedDeltaTime);
        }
        
    }
