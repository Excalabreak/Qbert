using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/31/2024]
 * [Script for enemies to decend down the map]
 */

public class EnemyDecendScript : MonoBehaviour
{
    private BaseHopScript _hopScript;

    private bool _firstDrop = true;
    [SerializeField] private float _speed = 3f;
    private Vector3 _firstDropEndLoc;

    [SerializeField] private float _chargeTime = 1f;
    private bool _isChargingJump = false;

    /// <summary>
    /// on awake, spawn ball at random location
    /// </summary>
    private void Awake()
    {
        _hopScript = gameObject.GetComponent<BaseHopScript>();

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
    /// in update, drop the ball from spawn.
    /// after, have ball randomly go down the map
    /// </summary>
    private void Update()
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
            if (!_hopScript.isHandlingJump)
            {
                if (!_isChargingJump)
                {
                    StartCoroutine(ChargeJump());
                }
            }
            else
            {
                _hopScript.HandleHop();
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
            _hopScript.Hop(DirectionEnum.DownLeft);
        }
        else
        {
            _hopScript.Hop(DirectionEnum.DownRight);
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
