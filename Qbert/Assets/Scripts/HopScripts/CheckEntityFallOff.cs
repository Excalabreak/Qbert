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
    [SerializeField] private float _limitValue = -19;
    [SerializeField] private bool _entityIsLessToDespawn = true;
    [SerializeField] private DownEnum _axis = DownEnum.y;
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
        if (_entityIsLessToDespawn)
        {
            switch (_axis)
            {
                case DownEnum.y:
                    if (transform.position.y <= _limitValue)
                    {
                        _deathScript.OnFallDeath();
                    }
                    break;
                case DownEnum.x:
                    if (transform.position.x <= _limitValue)
                    {
                        _deathScript.OnFallDeath();
                    }
                    break;
                case DownEnum.z:
                    if (transform.position.z <= _limitValue)
                    {
                        _deathScript.OnFallDeath();
                    }
                    break;
            }
        }
        else
        {
            switch (_axis)
            {
                case DownEnum.y:
                    if (transform.position.y >= _limitValue)
                    {
                        _deathScript.OnFallDeath();
                    }
                    break;
                case DownEnum.x:
                    if (transform.position.x >= _limitValue)
                    {
                        _deathScript.OnFallDeath();
                    }
                    break;
                case DownEnum.z:
                    if (transform.position.z >= _limitValue)
                    {
                        _deathScript.OnFallDeath();
                    }
                    break;
            }
        }
    }
}
