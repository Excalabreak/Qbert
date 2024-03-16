using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/16/2024]
 * [base script for anything that needs to move in this game]
 */

public class BaseHopScript : MonoBehaviour
{
    //needed components
    [SerializeField] protected GameObject _model;

    //is the player jumping
    protected bool _isHandlingJump = false;

    //current direction the player is facing/going
    protected DirectionEnum _currentDirection;

    //variables for interpolation
    protected Vector3 _startPos;
    protected Vector3 _currentPos;
    protected Vector3 _endPos;
    [SerializeField] protected float _timeDuration = 1f;
    protected bool _startMove = false;
    protected bool _moving = false;
    protected float _timeStart;

    /// <summary>
    /// will set the variables to hop
    /// </summary>
    /// <param name="direction"></param>
    public void Hop(DirectionEnum direction)
    {
        if (!_isHandlingJump)
        {
            _currentDirection = direction;
            RotateFacing();

            _startPos = transform.position;
            FindEndPos();

            _startMove = true;
            _isHandlingJump = true;

        }
    }
    /// <summary>
    /// called in update to move player when hopping
    /// </summary>
    public virtual void HandleHop()
    {

    }

    /// <summary>
    /// will rotate object to face move direction
    /// </summary>
    protected virtual void RotateFacing()
    {

    }

    /// <summary>
    /// find _endPos to jump to
    /// </summary>
    protected virtual void FindEndPos()
    {

    }
}
