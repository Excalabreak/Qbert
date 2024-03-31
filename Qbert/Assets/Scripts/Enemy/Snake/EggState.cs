using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggState : MonoBehaviour, ISnakeState
{
    private SnakeMoveScript _snakeMoveScript;

    private bool _firstDrop = true;
    private float _speed = 3f;
    private Vector3 _firstDropEndLoc;

    [SerializeField] private float _chargeTime = 1f;
    private bool _isChargingJump = false;

    /// <summary>
    /// on Handle, spawn egg at random location
    /// </summary>
    public void Handle(SnakeMoveScript snakeMoveScript)
    {
        if (!_snakeMoveScript)
        {
            _snakeMoveScript = snakeMoveScript;
        }

        int randomSpawn = Random.Range(0, 2);
        if (randomSpawn == 0)
        {
            transform.position = new Vector3(-1, 3, 0);
            _firstDropEndLoc = transform.position;
            _firstDropEndLoc.y = 0;
        }
        else
        {
            transform.position = new Vector3(0, 3, -1);
            _firstDropEndLoc = transform.position;
            _firstDropEndLoc.y = 0;
        }
    }

    /// <summary>
    /// in update if in egg state, 
    /// drop the egg from spawn.
    /// after, have ball randomly go down the map until it reaches bottom
    /// then hatch into snake
    /// </summary>
    private void Update()
    {
        if (_snakeMoveScript && _snakeMoveScript.inEggState)
        {
            if (_firstDrop)
            {
                Vector3 currentPos = transform.position + (Vector3.down * _speed * Time.deltaTime);
                if (currentPos.y <= _firstDropEndLoc.y)
                {
                    transform.position = _firstDropEndLoc;
                    _firstDrop = false;
                }
                else
                {
                    transform.position = currentPos;
                }
            }
            else
            {
                if (!_snakeMoveScript.hopScript.isHandlingJump)
                {
                    if (transform.position.y <= -5)
                    {
                        _snakeMoveScript.Hatch();
                    }
                    else if (!_isChargingJump)
                    {
                        StartCoroutine(ChargeJump());
                    }
                }
                else
                {
                    _snakeMoveScript.hopScript.HandleHop();
                }
            }
        }
    }

    /// <summary>
    /// jumps a random direction down
    /// </summary>
    private void Jump()
    {
        int randomDir = Random.Range(0, 2);
        if (randomDir == 0)
        {
            _snakeMoveScript.hopScript.Hop(DirectionEnum.DownLeft);
        }
        else
        {
            _snakeMoveScript.hopScript.Hop(DirectionEnum.DownRight);
        }
    }

    /// <summary>
    /// waits to jump before jumping
    /// </summary>
    /// <returns></returns>
    private IEnumerator ChargeJump()
    {
        _isChargingJump = true;
        yield return new WaitForSeconds(_chargeTime);
        Jump();
        _isChargingJump = false;
    }
}
