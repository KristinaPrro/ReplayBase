using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Example
{
    [RequireComponent(typeof(Rigidbody))]

    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.3f;
        [SerializeField] private float _jumpForce = 1f;

        private Rigidbody _rb;

        private Vector3 _movementVector
        {
            get
            {
                var horizontal = Input.GetAxis("Horizontal");
                var vertical = Input.GetAxis("Vertical");

                return new Vector3(horizontal, 0.0f, vertical);
            }
        }

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            MoveLogic();
            if (Input.GetAxis("Jump")>0)
                JumpLogic();
        }

        private void MoveLogic()
        {
            _rb.AddForce(_movementVector * _speed, ForceMode.Impulse);
        }

        private void JumpLogic()
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
