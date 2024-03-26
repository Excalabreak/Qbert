using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchedState : MonoBehaviour, ISnakeState
{
    private SnakeMoveScript _snakeMoveScript;

    [SerializeField] private float _chargeTime = 1f;
    private bool _isChargingJump = false;

    public void Handle(SnakeMoveScript snakeMoveScript)
    {
        if (!_snakeMoveScript)
        {
            _snakeMoveScript = snakeMoveScript;
        }
    }

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
            //if not jumping
            //call coroutine to jump
            //
            //else handle jump
        }
    }

    private void JumpTwoardsPlayer()
    {
        
    }

    private IEnumerator ChargeJump()
    {
        _isChargingJump = true;
        yield return new WaitForSeconds(_chargeTime);
        _isChargingJump = false;
    }
}
