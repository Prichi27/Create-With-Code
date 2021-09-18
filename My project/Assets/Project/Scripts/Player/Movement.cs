using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float gravity;
    [SerializeField] float jumpHeight;
    [SerializeField] LayerMask groundMask;

    CharacterController _controller;
    Vector2 _horizontalInput;
    Vector3 _verticalVelocity;
    bool _isGrounded;
    bool _isJumping;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);

        if (_isGrounded) _verticalVelocity.y = 0;

        if (_isGrounded && _isJumping)
        {
            _verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            _isJumping = false;
        }

        Vector3 horizontalVelocity = 
            (transform.right * _horizontalInput.x + transform.forward * _horizontalInput.y) 
            * speed 
            * Time.deltaTime;

        _controller.Move(horizontalVelocity);

        _verticalVelocity.y += gravity * Time.deltaTime;
        _controller.Move(_verticalVelocity * Time.deltaTime);
        
    }

    public void ReceiveInput (Vector2 horizontalInput)
    {
        _horizontalInput = horizontalInput;
    }

    public void SetIsJumping()
    {
        _isJumping = true;
    }
}
