using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/28/2024]
 * [Singleton that holds information about the map and cubes]
 */

public class MapManager : Singleton<MapManager>
{
    private Dictionary<Vector3, GameObject> _mapLandables = new Dictionary<Vector3, GameObject>();
    private Vector3 _playerLastLocation;

    [SerializeField] private GameObject _mapPrefab;
    [SerializeField] private GameObject _discPrefab;
    private GameObject _currentMap;

    //TODO: place in game manager
    //make map spawn
    //make map get child

    /// <summary>
    /// On Enabled, adds all child cubes and disc into _mapCubes dictionary
    /// </summary>
    private void OnEnable()
    {
        //line for testing, remove after
        MakeMap();
        
    }

    /// <summary>
    /// instantiates map from _mapPrefab
    /// </summary>
    private void MakeMap()
    {
        _currentMap = Instantiate(_mapPrefab, Vector3.zero, Quaternion.identity);

        foreach (Transform child in _currentMap.transform)
        {
            if (child.gameObject.tag == "Cube" || child.gameObject.tag == "Disc")
            {
                _mapLandables.Add(child.position, child.gameObject);
            }
        }

        SpawnDisc(true, 4);
        SpawnDisc(false, 4);
    }

    /// <summary>
    /// spawns disc based on parameters
    /// </summary>
    /// <param name="onLeftSide">is the disc spawning on the left</param>
    /// <param name="row">row in which the disc spawns</param>
    private void SpawnDisc(bool onLeftSide, int row)
    {
        if (row < 0 || row > 6)
        {
            Debug.Log("cant spawn on row " + row);
        }
        else
        {
            float fRow = (float)row * -1;
            Vector3 spawnLoc;
            GameObject disc;
            if (onLeftSide)
            {
                spawnLoc = new Vector3(fRow, fRow+1, 1);
                disc = Instantiate(_discPrefab, spawnLoc, Quaternion.identity);
            }
            else
            {
                spawnLoc = new Vector3(1, fRow + 1, fRow);
                disc = Instantiate(_discPrefab, spawnLoc, Quaternion.identity);
            }
            disc.transform.parent = _currentMap.transform;
            _mapLandables.Add(spawnLoc, disc);
        }
        
    }

    public void UpdatePlayerLastLocation(Vector3 loc)
    {
        _playerLastLocation = loc;
    }

    /// <summary>
    /// destroys and removes the map landable by the SPAWNED position key
    /// </summary>
    /// <param name="landable">KEY of landable</param>
    public void RemoveLandable(Vector3 landable)
    {
        GameObject temp;
        if (_mapLandables.TryGetValue(landable, out temp))
        {
            Debug.Log(temp);
            Destroy(temp);
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
