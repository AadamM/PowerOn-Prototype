using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jumpForce;

    private Rigidbody2D _rigidbody;
    private Transform _transform;

    private float HorizontalMovement
    {
        get { return Input.GetAxis("Horizontal"); }
    }

    private bool JumpButtonPressed
    {
        get { return Input.GetKeyDown(KeyCode.Space); }
    }

    private bool IsGrounded
    {
        get { return _rigidbody.velocity.y == 0; }
    }

    // Use this for initialization
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleHorizontalMovement();
        HandleJumping();
	}

    private void HandleHorizontalMovement()
    {
        var newVelocity = _rigidbody.velocity;
        newVelocity.x = HorizontalMovement * speed;
        _rigidbody.velocity = newVelocity;
    }

    private void HandleJumping()
    {
        if (JumpButtonPressed && IsGrounded)
        {
            var up = _transform.TransformDirection(Vector2.up);
            _rigidbody.AddForce(up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
