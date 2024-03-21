using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/21/2024]
 * [Script for when qbert lands on dixc]
 */

public class DiscScript : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Vector3 _endPos = new Vector3(1, 1, 1);
    public Vector3 _direction;

    private bool _atEndPos = false;

    private GameObject _playerGameObject;

    private void Awake()
    {
        _direction = _endPos - transform.position;
        Vector3.Normalize(_direction);
    }

    private void Update()
    {
        if (_playerGameObject != null)
        {
            BaseHopScript playerHopScript = _playerGameObject.gameObject.GetComponent<BaseHopScript>();
            if (playerHopScript.onDisc && !playerHopScript.isHandlingJump && !_atEndPos)
            {
                if (_playerGameObject.transform.parent != transform)
                {
                    _playerGameObject.transform.parent = transform;
                }

                Vector3 currentPos = transform.position + (_direction * _speed * Time.deltaTime);
                if (currentPos.y >= _endPos.y)
                {
                    transform.position = _endPos;
                    _atEndPos = true;
                }
                else
                {
                    transform.position = currentPos;
                }
            }

            if (_atEndPos)
            {
                _playerGameObject.transform.parent = null;
                _playerGameObject.transform.position = _playerGameObject.GetComponent<PlayerSpawnScript>().spawnLoc;
                playerHopScript.CompleteDiscRide();
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// on trigger stay,
    /// sets the player gameobject to start
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerGameObject = other.gameObject;
        }
    }
}
