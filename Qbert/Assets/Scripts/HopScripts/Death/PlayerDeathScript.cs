using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [player's death script]
 */

public class PlayerDeathScript : BaseDeathScript
{
    public override void OnFallDeath()
    {
        OnPlayerDeath();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            OnPlayerDeath();
        }
    }

    private void OnPlayerDeath()
    {
        LiveMananger.Instance.OnDeath();
        Destroy(gameObject);
    }
}
