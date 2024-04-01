using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
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
    [SerializeField] protected float _speed = 1.4f;

    //var for on disc
    protected bool _onDisc = false;

    /// <summary>
    /// will set the variables to hop
    /// </summary>
    /// <param name="direction">direction enum of which direction to jump</param>
    public void Hop(DirectionEnum direction)
    {
        if (!_isHandlingJump && !_onDisc)
        {
            _currentDirection = direction;
            RotateFacing();

            _startPos = transform.position;
            FindEndPos();

            if (!MapManager.Instance.CheckForLandable(_endPos + Vector3.down))
            {
                _endPos.y = -20;
            }
            else if (!MapManager.Instance.CheckForCube(_endPos + Vector3.down))
            {
                if (gameObject.tag == "Player")
                {
                    _onDisc = true;
                }
                else
                {
                    _endPos.y = -20;
                }
            }

            if (gameObject.tag == "Player")
            {
                MapManager.Instance.UpdatePlayerLastLocation(_endPos);
            }

            _isHandlingJump = true;
        }
    }

    /// <summary>
    /// will set the variables to hop
    /// </summary>
    /// <param name="direction">direction enum of which direction to jump</param>
    /// <param name="down">axis to check</param>
    public void Hop(DirectionEnum direction, DownEnum down)
    {
        if (!_isHandlingJump && !_onDisc)
        {
            _currentDirection = direction;
            RotateFacing();

            _startPos = transform.position;
            FindEndPos();

            Vector3 axisDown;
            switch (down)
            {
                case DownEnum.y:
                    axisDown = Vector3.down;
                    break;
                case DownEnum.x:
                    axisDown = Vector3.right;
                    break;
                case DownEnum.z:
                    axisDown = Vector3.forward;
                    break;
                default:
                    axisDown = Vector3.down;
                    break;
            }

            if (!MapManager.Instance.CheckForLandable(_endPos + axisDown))
            {
                switch (down)
                {
                    case DownEnum.y:
                        _endPos.y = -20;
                        break;
                    case DownEnum.x:
                        _endPos.x = 20;
                        break;
                    case DownEnum.z:
                        _endPos.z = 20;
                        break;
                }
            }
            else if (!MapManager.Instance.CheckForCube(_endPos + axisDown))
            {
                if (gameObject.tag == "Player")
                {
                    _onDisc = true;
                }
                else
                {
                    switch (down)
                    {
                        case DownEnum.y:
                            _endPos.y = -20;
                            break;
                        case DownEnum.x:
                            _endPos.x = 20;
                            break;
                        case DownEnum.z:
                            _endPos.z = 20;
                            break;
                    }

                    _endPos.y = -20;
                }
            }

            if (gameObject.tag == "Player")
            {
                MapManager.Instance.UpdatePlayerLastLocation(_endPos);
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

    /// <summary>
    /// changes speed through code
    /// </summary>
    /// <param name="speed">new speed float</param>
    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }

    /// <summary>
    /// changes model through code
    /// </summary>
    /// <param name="model">game object with model</param>
    public void ChangeModel(GameObject model)
    {
        _model = model;
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

    public bool frozen
    {
        get { return _frozen; }
        set { _frozen = value; }
    }
}
