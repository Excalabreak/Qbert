using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/23/2024]
 * [Script to check fall if game object falls off and calls for game over]
 */

public class CheckEntityFallOff : MonoBehaviour
{
    [SerializeField] private Vector3 _depthLimits = new Vector3(-19f, -19f, -19f);
    private BaseDeathScript _deathScript;

    private void Awake()
    {
        _deathScript = GetComponent<BaseDeathScript>();
    }

    /// <summary>
    /// every frame, checks to see if game object is too low to be on screen
    /// </summary>
    void Update()
    {
        if (transform.position.x < _depthLimits.x || transform.position.y < _depthLimits.y || transform.position.z < _depthLimits.z)
        {
            _deathScript.OnDeath();
        }
    }
}
