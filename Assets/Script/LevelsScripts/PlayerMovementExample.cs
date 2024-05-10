using System;
using UnityEngine;

public class PlayerMovementExample : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float maxVelocityChange = 10;

    private Vector2 _input;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        _input.Normalize();
    }

    Vector3 CalculateMovement(float speed)
    {
        Vector3 _targetVelocity = new Vector3();
        return _targetVelocity;
    }
}
