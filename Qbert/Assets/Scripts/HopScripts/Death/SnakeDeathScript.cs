using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/25/2024]
 * [Snake will give points when falls off]
 */

public class SnakeDeathScript : BaseDeathScript
{
    /// <summary>
    /// calls to give points when snake falls off
    /// </summary>
    public override void OnFallDeath()
    {
        ScoreManager.Instance.AddScore(500);
        base.OnFallDeath();
    }
}
