using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/18/2024]
 * [overrides the base hop function so things can hop on the y axis]
 */

public class YAxisHopScript : BaseHopScript
{
    [SerializeField] private PlayerSpawnScript playerSpawnScript;

    /// <summary>
    /// Handles hopping motion
    /// TODO: make it check for death and adjust numbers aproprietly
    /// TODO: needs to be able to freeze
    /// </summary>
    public override void HandleHop()
    {
        //Debug.Log(gameObject.name + " " + _frozen);
        if (_isHandlingJump && !_frozen)
        {
            Vector3 movePos = transform.position + (_direction * _speed * Time.deltaTime);

            float distanceU;
            float distanceTraveled;
            float totalDistance;
            if (_direction.x != 0)
            {
                distanceTraveled = movePos.x - _startPos.x;
                totalDistance = _endPos.x - _startPos.x;
            }
            else
            {
                distanceTraveled = movePos.z - _startPos.z;
                totalDistance = _endPos.z - _startPos.z;
            }
            distanceU = distanceTraveled / totalDistance;

            if (distanceU > 1)
            {
                transform.position = _endPos;
                _isHandlingJump = false;
                if (playerSpawnScript != null)
                {
                    if (playerSpawnScript.justSpawned)
                    {
                        playerSpawnScript.FirstJump();
                    }
                    MapManager.Instance.CheckCompleteMap();
                }
                return;
            }

            if (_currentDirection == DirectionEnum.DownRight || _currentDirection == DirectionEnum.DownLeft)
            {
                movePos.y = GetHeight(distanceU, .5f);
            }
            else
            {
                movePos.y = GetHeight(distanceU, 1.5f);
            }

            transform.position = movePos;
        }
    }

    /// <summary>
    /// calculates the height of the object when jumping using interpolation
    /// </summary>
    /// <param name="distPercent">current u of whole jump</param>
    /// <param name="jumpHeight">how high from starting position will game object jump</param>
    protected float GetHeight(float distPercent, float jumpHeight)
    {
        if (distPercent <= .5f)
        {
            float jumpU = distPercent / .5f;
            jumpU = 1 - Mathf.Pow(1 - jumpU, 2.5f);
            return (1 - jumpU) * _startPos.y + jumpU * (_startPos.y + jumpHeight);
        }
        else
        {
            float fallU = (distPercent - .5f) / .5f;
            fallU = Mathf.Pow(fallU, 2.5f);
            return (1 - fallU) * (_startPos.y + jumpHeight) + fallU * _endPos.y;
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

    /// <summary>
    /// sets the vector 3 direction and sets the end position
    /// </summary>
    protected override void FindEndPos()
    {
        switch (_currentDirection)
        {
            case DirectionEnum.UpRight:
                _direction = new Vector3(1, 1, 0);
                break;
            case DirectionEnum.DownRight:
                _direction = new Vector3(0, -1, -1);
                break;
            case DirectionEnum.UpLeft:
                _direction = new Vector3(0, 1, 1);
                break;
            case DirectionEnum.DownLeft:
                _direction = new Vector3(-1, -1, 0);
                break;
        }
        _endPos = transform.position + _direction;
    }
}
