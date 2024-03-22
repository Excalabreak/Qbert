using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/21/2024]
 * [Script for handling red ball's movement]
 */

public class RedBallMoveScript : MonoBehaviour
{
    private BaseHopScript _hopScript;

    private bool _firstDrop = true;
    [SerializeField] private float _speed = 1.75f;

    private Vector3 _spawnLoc;
    private Vector3 _firstDropEndLoc;

    private void Awake()
    {
        _hopScript = gameObject.GetComponent<BaseHopScript>();

        int randomSpawn = Random.Range(0, 2);
        if (randomSpawn == 0)
        {
            transform.position = new Vector3(-1, 3, 0);
            _spawnLoc = transform.position;
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
            else
            {
                _hopScript.HandleHop();
            }
        }
    }
}
