using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _xInput;
    [SerializeField]
    private float _speed = 100;
    private bool _performJump;
    private bool _isGrounded;
    [SerializeField]
    private float _jumpForce = 300;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _performJump = true;
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_xInput * _speed * Time.deltaTime, _rb.linearVelocity.y);

        if (_performJump)
        {
            _rb.AddForce(new Vector2(0, _jumpForce * Time.deltaTime), ForceMode2D.Impulse);
            _performJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}
