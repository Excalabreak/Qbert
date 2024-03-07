using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/07/2024]
 * [Manages player]
 */

public class PlayerManager : MonoBehaviour
{
    //needed components
    private InputManager _inputManager;
    private PlayerLocomotion _playerLocomotion;

    /// <summary>
    /// gets all needed components
    /// </summary>
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    /// <summary>
    /// calls functions needed every frame
    /// </summary>
    private void Update()
    {
        _inputManager.HandleAllInputs();
        _playerLocomotion.HandleMove();
    }
}
