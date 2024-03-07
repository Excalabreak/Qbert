using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/07/2024]
 * [Manages movement for player]
 */

public class PlayerLocomotion : MonoBehaviour
{
    //needed components
    private InputManager _inputManager;
    private MoveScript _moveScript;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _moveScript = GetComponent<MoveScript>();
    }

    public void HandleMove()
    {
        if (_inputManager.verticalInput == 1)
        {
            _moveScript.Hop(DownEnum.y, DirectionEnum.UpRight);
        }
        else if (_inputManager.verticalInput == -1)
        {
            _moveScript.Hop(DownEnum.y, DirectionEnum.DownLeft);
        }
        else if (_inputManager.horizontalInput == 1)
        {
            _moveScript.Hop(DownEnum.y, DirectionEnum.DownRight);
        }
        else if (_inputManager.horizontalInput == -1)
        {
            _moveScript.Hop(DownEnum.y, DirectionEnum.UpLeft);
        }
    }
}
