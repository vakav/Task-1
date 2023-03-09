using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class JoystickMove : MonoBehaviour
    {

        [SerializeField] private Joystick _joystick;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField]private ClickMove _clickMove;


        [SerializeField] private float _speed = 3f;


        private void Start() {
            _clickMove = GetComponent<ClickMove>();
        }


         private void FixedUpdate() 
        {
            Vector3 joystickInput = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
            if (joystickInput.sqrMagnitude != 0)
            {
                _rigidbody.MovePosition(transform.position + joystickInput * Time.fixedDeltaTime * _speed);
                _clickMove.StopMove();
            }
        }
    
    }
}