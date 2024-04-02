using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Base script for green enemies]
 */

public class BaseGreenDeathScript : BaseDeathScript
{
    [SerializeField] private bool _isBall = false;

    protected virtual void OnContactDeath()
    {
        if (_isBall)
        {
            EnemyManager.Instance.FreezeAllEnemies();
        }
        ScoreManager.Instance.AddScore(_points);
        EnemyManager.Instance.RemoveEnemy(gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnContactDeath();
        }
    }
}
