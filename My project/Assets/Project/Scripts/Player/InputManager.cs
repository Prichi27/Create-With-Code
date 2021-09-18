using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement), typeof(MouseController), typeof(Shoot))]
public class InputManager : MonoBehaviour
{
    Movement _movement;
    MouseController _mouse;
    Shoot _shoot;

    PlayerInput _input;
    PlayerInput.GroundMovementActions _groundMovement;

    Vector2 _horizontalInput;
    Vector2 _mouseInput;

    private void Awake()
    {
        _input = new PlayerInput();
        _groundMovement = _input.GroundMovement;
        _movement = GetComponent<Movement>();
        _mouse = GetComponent<MouseController>();
        _shoot = GetComponent<Shoot>();

        _groundMovement.HorizontalMovement.performed += ctx => _horizontalInput = ctx.ReadValue<Vector2>();
        _groundMovement.Jump.performed += _ => _movement.SetIsJumping();

        _groundMovement.HorizontalLook.performed += ctx => _mouseInput.x = ctx.ReadValue<float>();
        _groundMovement.VerticalLook.performed += ctx => _mouseInput.y = ctx.ReadValue<float>();

        _groundMovement.Shoot.performed += _ => _shoot.TriggerShoot();
    }

    private void Update()
    {
        _movement.ReceiveInput(_horizontalInput);
        _mouse.ReceiveInput(_mouseInput);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
