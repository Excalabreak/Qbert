using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/28/2024]
 * [Script for when qbert lands on disc]
 */

public class DiscScript : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Vector3 _endPos = new Vector3(1, 1, 1);
    private Vector3 _spawnPos;
    public Vector3 _direction;

    private bool _atEndPos = false;

    private GameObject _playerGameObject;

    private void Awake()
    {
        _direction = _endPos - transform.position;
        Vector3.Normalize(_direction);
        _spawnPos = transform.position;
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
                Vector3 returnPos = _playerGameObject.GetComponent<PlayerSpawnScript>().spawnLoc;
                _playerGameObject.transform.position = returnPos;
                MapManager.Instance.UpdatePlayerLastLocation(returnPos);
                playerHopScript.CompleteDiscRide();
                MapManager.Instance.RemoveLandable(_spawnPos);
            }
        }
    }

    /// <summary>
    /// on trigger enter,
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
