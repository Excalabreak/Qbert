using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/21/2024]
 * [Script when Qbert spawns]
 */

public class PlayerSpawnScript : MonoBehaviour
{
    //spawn location
    [SerializeField] private Vector3 _spawnLoc = new Vector3(0, 1, 0);

    //bools if player just spawn
    private bool _justSpawned = true;

    /// <summary>
    /// makes sure that _just spawned is true when created
    /// </summary>
    private void Awake()
    {
        _justSpawned = true;
    }

    /// <summary>
    /// called after the first jump to set it to false
    /// </summary>
    public void FirstJump()
    {
        _justSpawned = false;
    }

    //properties

    public Vector3 spawnLoc
    {
        get { return _spawnLoc; }
    }

    public bool justSpawned
    {
        get { return _justSpawned; }
    }
}
