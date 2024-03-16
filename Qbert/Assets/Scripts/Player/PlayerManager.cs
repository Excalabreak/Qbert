using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/16/2024]
 * [Manages player]
 */

public class PlayerManager : MonoBehaviour
{
    //needed components
    private InputManager _inputManager;
    private PlayerLocomotion _playerLocomotion;
    private PlayerHopScript _playerHopScript;

    /// <summary>
    /// gets all needed components
    /// </summary>
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
        _playerHopScript = GetComponent<PlayerHopScript>();
    }

    /// <summary>
    /// calls functions needed every frame
    /// </summary>
    private void Update()
    {
        _inputManager.HandleAllInputs();
        _playerLocomotion.HandleMove();
        _playerHopScript.HandleHop();
    }
}
