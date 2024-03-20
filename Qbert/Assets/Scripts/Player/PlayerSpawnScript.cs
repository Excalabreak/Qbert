using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/19/2024]
 * [Script when Qbert spawns]
 */

public class PlayerSpawnScript : MonoBehaviour
{
    private bool _justSpawned = true;

    private void Awake()
    {
        _justSpawned = true;
    }

    public void FirstJump()
    {
        _justSpawned = false;
    }

    public bool justSpawned
    {
        get { return _justSpawned; }
    }
}
