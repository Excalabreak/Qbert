using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchedState : MonoBehaviour, ISnakeState
{
    private SnakeMoveScript _snakeMoveScript;

    [SerializeField] private float _chargeTime = 1f;
    private bool _isChargingJump = false;

    /// <summary>
    /// sets _snakeMoveScript that starts this state
    /// </summary>
    /// <param name="snakeMoveScript"></param>
    public void Handle(SnakeMoveScript snakeMoveScript)
    {
        if (!_snakeMoveScript)
        {
            _snakeMoveScript = snakeMoveScript;
        }
    }

    /// <summary>
    /// calls to handle jump or charge a jump depending on bools
    /// </summary>
    private void Update()
    {
        if (_snakeMoveScript && !_snakeMoveScript.inEggState)
        {
            if (!_snakeMoveScript.hopScript.isHandlingJump)
            {
                if (!_isChargingJump)
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

    /// <summary>
    /// gets the players last location and jumps twoards the player
    /// </summary>
    private void JumpTwoardsPlayer()
    {
        Vector3 playerLoc = MapManager.Instance.playerLastLocation;
        if (playerLoc.y > transform.position.y)
        {
            if (playerLoc.x - playerLoc.z > transform.position.x - transform.position.z)
            {
                _snakeMoveScript.hopScript.Hop(DirectionEnum.UpRight);
            }
            else
            {
                _snakeMoveScript.hopScript.Hop(DirectionEnum.UpLeft);
            }
        }
        else
        {
            if (playerLoc.x - playerLoc.z > transform.position.x - transform.position.z)
            {
                _snakeMoveScript.hopScript.Hop(DirectionEnum.DownRight);
            }
            else
            {
                _snakeMoveScript.hopScript.Hop(DirectionEnum.DownLeft);
            }
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
        JumpTwoardsPlayer();
        _isChargingJump = false;
    }
}
