using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/26/2024]
 * [Manages all inputs from new input system]
 */

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    private Vector2 _moveInput;

    private void Update()
    {
        Debug.Log(_moveInput);
    }

    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();

            _playerControls.PlayerMovement.Movement.performed += context => _moveInput = context.ReadValue<Vector2>();
        }

        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
