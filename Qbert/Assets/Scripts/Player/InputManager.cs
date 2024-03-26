using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/25/2024]
 * [Manages all inputs from new input system]
 */

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    private Vector2 _moveInput;
    private float _verticalInput;
    private float _horizontalInput;

    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();

            _playerControls.PlayerMovement.Movement.performed += context => _moveInput = context.ReadValue<Vector2>();
        }

        _playerControls.Enable();
    }

    public void HandleAllInputs()
    {
        HandleMoveInput();
    }

    private void HandleMoveInput()
    {
        _verticalInput = _moveInput.y;
        _horizontalInput = _moveInput.x;
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    public float verticalInput
    {
        get { return _verticalInput; }
    }

    public float horizontalInput
    {
        get { return _horizontalInput; }
    }
}
