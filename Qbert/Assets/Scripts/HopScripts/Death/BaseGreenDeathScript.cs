using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/31/2024]
 * [Base script for green enemies]
 */

public class BaseGreenDeathScript : BaseDeathScript
{
    [SerializeField] private int _points = 100;

    protected virtual void OnContactDeath()
    {
        Destroy(this.gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //freeze all enemies
            OnContactDeath();
        }
    }
}
