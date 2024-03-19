using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/16/2024]
 * [overrides the base hop function so things can hop on the y axis]
 */

public class YAxisHopScript : BaseHopScript
{
    /// <summary>
    /// Handles player hopping motion
    /// NOTE: make it check for death and adjust numbers aproprietly
    /// </summary>
    public override void HandleHop()
    {
        if (_isHandlingJump)
        {
            if (_startMove)
            {
                _startMove = false;

                _moving = true;
                _timeStart = Time.time;
            }

            if (_moving)
            {
                float u = (Time.time - _timeStart) / _timeDuration;

                if (u >= 1)
                {
                    u = 1;
                    _moving = false;
                }

                _currentPos = (1 - u) * _startPos + u * _endPos;

                if (_currentDirection == DirectionEnum.DownLeft || _currentDirection == DirectionEnum.DownRight)
                {
                    InterpolateJumpHeight(u, .5f);
                }
                else
                {
                    InterpolateJumpHeight(u, 1.5f);
                }

                transform.position = _currentPos;

                if (!_moving)
                {
                    _isHandlingJump = false;
                }
            }
        }
    }

    /// <summary>
    /// interpolates the jump height differently from x axis
    /// </summary>
    /// <param name="u">current u of whole jump</param>
    /// <param name="jumpHeight">how high from starting position will game object jump</param>
    protected void InterpolateJumpHeight(float u, float jumpHeight)
    {
        if (u <= .5f)
        {
            float jumpU = u / .5f;
            jumpU = 1 - Mathf.Pow(1 - jumpU, 2.5f);
            _currentPos.y = (1 - jumpU) * _startPos.y + jumpU * (_startPos.y + jumpHeight);
        }
        else
        {
            float fallU = (u - .5f) / .5f;
            fallU = Mathf.Pow(fallU, 2.5f);
            _currentPos.y = (1 - fallU) * (_startPos.y + jumpHeight) + fallU * _endPos.y;
        }
    }

    /// <summary>
    /// Rotates Model to face move direction
    /// maybe need to make it's own script
    /// </summary>
    protected override void RotateFacing()
    {
        if (_model != null)
        {
            switch (_currentDirection)
            {
                case DirectionEnum.UpRight:
                    _model.transform.eulerAngles = new Vector3(0, 270, 0);
                    break;
                case DirectionEnum.DownRight:
                    _model.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case DirectionEnum.UpLeft:
                    _model.transform.eulerAngles = new Vector3(0, 180, 0);
                    break;
                case DirectionEnum.DownLeft:
                    _model.transform.eulerAngles = new Vector3(0, 90, 0);
                    break;
            }
        }
    }

    protected override void FindEndPos()
    {
        switch (_currentDirection)
        {
            case DirectionEnum.UpRight:
                _endPos = transform.position + new Vector3(1, 1, 0);
                break;
            case DirectionEnum.DownRight:
                _endPos = transform.position + new Vector3(0, -1, -1);
                break;
            case DirectionEnum.UpLeft:
                _endPos = transform.position + new Vector3(0, 1, 1);
                break;
            case DirectionEnum.DownLeft:
                _endPos = transform.position + new Vector3(-1, -1, 0);
                break;
        }
    }
}
