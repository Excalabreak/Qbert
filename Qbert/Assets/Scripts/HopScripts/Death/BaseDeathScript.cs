using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/31/2024]
 * [Script that can be overriden to call for death for enemies]
 */

public class BaseDeathScript : MonoBehaviour
{
    [SerializeField] protected int _points = 100;

    /// <summary>
    /// when called, destroy this gameobjcet
    /// (can be used as is or overriden to do more)
    /// </summary>
    public virtual void OnFallDeath()
    {
        EnemyManager.Instance.RemoveEnemy(gameObject);
    }
}
