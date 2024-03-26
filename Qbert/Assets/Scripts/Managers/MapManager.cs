using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/25/2024]
 * [Singleton that holds information about the map and cubes]
 */

public class MapManager : Singleton<MapManager>
{
    private Dictionary<Vector3, GameObject> _mapLandables = new Dictionary<Vector3, GameObject>();
    public Vector3 _playerLastLocation;

    //TODO: place in game manager
    //make map spawn
    //make map get child
    //make disc removed from list when used

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

    public void UpdatePlayerLastLocation(Vector3 loc)
    {
        _playerLastLocation = loc;
    }

    public void RemoveLandable(Vector3 landable)
    {
        GameObject temp;
        if (_mapLandables.TryGetValue(landable, out temp))
        {
            _mapLandables.Remove(landable);
        }
    }

    /// <summary>
    /// Checks for a cube or disc to land on
    /// </summary>
    /// <param name="space">Vector 3 of Cube/Disc</param>
    /// <returns>returns true if there is a space for game object to land</returns>
    public bool CheckForLandable(Vector3 space)
    {
        return _mapLandables.ContainsKey(space);
    }

    public bool CheckForCube(Vector3 space)
    {
        return (_mapLandables.ContainsKey(space) && _mapLandables[space].tag == "Cube");
    }

    public Vector3 playerLastLocation
    {
        get { return _playerLastLocation; }
    }
}
