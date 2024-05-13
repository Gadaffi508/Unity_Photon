using System;
using UnityEngine;

public class PlayerMovementExample : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float sprintSpeed = 14f;
    public float maxVelocityChange = 10f;
    [Space] public float jumpHeight = 5f;
    [Space] public float airControl = 0.5f;

    private Vector2 _input;
    private Rigidbody _rb;

    private bool _sprinting;
    private bool _jumping;
    private bool _grounded = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _input.Normalize();

        _sprinting = Input.GetKey(KeyCode.LeftShift);
        _jumping = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (_grounded == false)
        {
            _rb.AddForce(CalculateMovement(_sprinting ? sprintSpeed * airControl : walkSpeed * airControl), ForceMode.VelocityChange);
            return;
        }
        if (_jumping)
        {
            _rb.velocity = new Vector3(_rb.velocity.x,jumpHeight,_rb.velocity.z);
            _grounded = false;
        }
        else _rb.AddForce(CalculateMovement(_sprinting ? sprintSpeed : walkSpeed), ForceMode.VelocityChange);
    }

    Vector3 CalculateMovement(float speed)
    {
        Vector3 _targetVelocity = new Vector3(_input.x, 0, _input.y);
        _targetVelocity = transform.TransformDirection(_targetVelocity);
        _targetVelocity *= speed;

        Vector3 velocity = _rb.velocity;
        if (_input.magnitude > 0.5f)
        {
            Vector3 velocityChange = _targetVelocity - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            return (velocityChange);
        }
        else return new Vector3();
    }

    private void OnTriggerStay(Collider other)
    {
        _grounded = true;
    }
}