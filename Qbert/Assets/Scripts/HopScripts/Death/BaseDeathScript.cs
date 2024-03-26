using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/23/2024]
 * [Script that can be overriden to call for death]
 */

public class BaseDeathScript : MonoBehaviour
{
    /// <summary>
    /// when called, destroy this gameobjcet
    /// (can be used as is or overriden to do more)
    /// </summary>
    public virtual void OnFallDeath()
    {
        Destroy(gameObject);
    }
}
