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
    [SerializeField] private bool _isBall = false;
    [SerializeField] private int _points = 300;

    protected virtual void OnContactDeath()
    {
        if (_isBall)
        {
            //freeze enemies
        }
        //add points
        Destroy(this.gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnContactDeath();
        }
    }
}
