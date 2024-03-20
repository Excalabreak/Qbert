using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/19/2024]
 * [Singleton that holds information about the map and cubes]
 */

public class MapManager : Singleton<MapManager>
{
    private Dictionary<Vector3, GameObject> _mapLandables = new Dictionary<Vector3, GameObject>();

    /// <summary>
    /// On Enabled, adds all child cubes and disc into _mapCubes dictionary
    /// </summary>
    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Cube" || child.gameObject.tag == "Disc")
            {
                _mapLandables.Add(child.position, child.gameObject);
            }
        }
    }

    /// <summary>
    /// Checks for a cube or disc to land on
    /// </summary>
    /// <param name="space">Vector 3 of Cube/Disc</param>
    /// <returns>returns true if there is a space for game object to land</returns>
    public bool CheckForLandable(Vector3 space)
    {
        if (_mapLandables.ContainsKey(space))
        {
            return true;
        }
        return false;
    }
}
