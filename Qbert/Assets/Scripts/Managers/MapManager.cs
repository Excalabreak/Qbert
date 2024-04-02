using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Singleton that holds information about the map and cubes]
 */

public class MapManager : Singleton<MapManager>
{
    private Dictionary<Vector3, GameObject> _mapLandables = new Dictionary<Vector3, GameObject>();
    private Vector3 _playerLastLocation;

    [SerializeField] private GameObject _mapPrefab;
    [SerializeField] private GameObject _discPrefab;
    private GameObject _currentMap;

    [SerializeField] private int[] _landGoals;
    [SerializeField] private bool[] _changeGoals;

    /// <summary>
    /// instantiates map from _mapPrefab
    /// </summary>
    public void MakeMap()
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

    /// <summary>
    /// sets player's last location
    /// </summary>
    /// <param name="loc"></param>
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
            Destroy(temp);
            _mapLandables.Remove(landable);
        }
    }

    /// <summary>
    /// Checks if the player has completed the map
    /// </summary>
    /// <returns>returns true if all spaces are at target</returns>
    public void CheckCompleteMap()
    {
        bool complete = true;
        foreach (KeyValuePair<Vector3, GameObject> landable in _mapLandables)
        {
            if (landable.Value.tag == "Cube")
            {
                if (!landable.Value.GetComponent<CubeScript>().IsGoalState())
                {
                    complete = false;
                }
            }
        }

        if (complete)
        {
            ScoreManager.Instance.AddScore(1000 + (LevelManager.Instance.currentLevel * 250));
            //call for next level
        }
    }

    /// <summary>
    /// sets all cubes to the objective
    /// </summary>
    public void SetMapCubesObjective()
    {
        int curLevel = LevelManager.Instance.currentLevel;
        foreach (KeyValuePair<Vector3, GameObject> landable in _mapLandables)
        {
            if (landable.Value.tag == "Cube")
            {
                landable.Value.GetComponent<CubeScript>().SetObjectiveRules(_landGoals[curLevel], _changeGoals[curLevel]);
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
        return _mapLandables.ContainsKey(space);
    }

    /// <summary>
    /// checks if space is a cube
    /// </summary>
    /// <param name="space"></param>
    /// <returns></returns>
    public bool CheckForCube(Vector3 space)
    {
        return (_mapLandables.ContainsKey(space) && _mapLandables[space].tag == "Cube");
    }

    /// <summary>
    /// property to get player's last location
    /// </summary>
    public Vector3 playerLastLocation
    {
        get { return _playerLastLocation; }
    }
}
