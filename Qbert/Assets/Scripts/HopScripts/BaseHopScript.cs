using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/21/2024]
 * [base script for anything that needs to move in this game]
 */

public class BaseHopScript : MonoBehaviour
{
    //needed components
    [SerializeField] protected GameObject _model;

    //is the player jumping
    protected bool _isHandlingJump = false;
    protected bool _frozen = false;

    //current direction the player is facing/going
    protected DirectionEnum _currentDirection;

    //variables for move
    protected Vector3 _startPos;
    protected Vector3 _direction;
    protected Vector3 _endPos;
    [SerializeField] protected float _speed = 5;

    //var for on disc
    protected bool _onDisc = false;

    /// <summary>
    /// will set the variables to hop
    /// </summary>
    /// <param name="direction">direction enum of which direction to jump</param>
    public void Hop(DirectionEnum direction)
    {
        if (!_isHandlingJump || !_onDisc)
        {
            _currentDirection = direction;
            RotateFacing();

            _startPos = transform.position;
            FindEndPos();

            if (!MapManager.Instance.CheckForLandable(_endPos + Vector3.down))
            {
                Debug.Log(gameObject.name + "Fell Off");
                _endPos.y = -20;
            }
            else if (!MapManager.Instance.CheckForCube(_endPos))
            {
                _onDisc = true;
            }

            _isHandlingJump = true;
        }
    }

    /// <summary>
    /// called when the dic has returned player to the top
    /// </summary>
    public void CompleteDiscRide()
    {
        _onDisc = false;
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

    //properties to get variables

    public bool isHandlingJump
    {
        get { return _isHandlingJump; }
    }

    public bool onDisc
    {
        get { return _onDisc; }
    }
}
