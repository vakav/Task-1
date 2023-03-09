using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ClickMove : MonoBehaviour
    {
        private Vector3 _target;
        private bool _isMove = false;

        [SerializeField] private Camera _camera;
        [SerializeField] private Rigidbody _rigidbody;


        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _distance = 100f;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _deadZone = 0.05f;


        public void StopMove()
        {
            _isMove = false;
        }


        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, _distance, _layerMask))
                {
                    _target = hit.point;
                    _isMove = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (_isMove)
                {
                    Vector3 direction = _target - transform.position;
                    direction.y = 0;
                    if (direction.sqrMagnitude > 1)
                        direction.Normalize();

                    _rigidbody.MovePosition(transform.position + direction * Time.fixedDeltaTime * _speed);

                    _isMove = direction.sqrMagnitude > _deadZone;
                }
        }
    }
}   