using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Script for each tile]
 */

public class CubeScript : MonoBehaviour
{
    //materials
    [SerializeField] private Material[] _topMats;
    [SerializeField] private MeshRenderer _topRenderer;

    //cube info
    private int _currentTopState = 0;
    private int _goalTopState = 1;
    private bool _canChangeGoalState = false;

    //vars if this cube is the spawn cube
    [SerializeField] private bool _spawnCube = false;

    /// <summary>
    /// sets what the rules for the goal states are
    /// </summary>
    /// <param name="landsToGoal">how many times qubert has to land on cube for objective</param>
    /// <param name="changeableGoal">can the goal states change back to non goal states</param>
    public void SetObjectiveRules(int landsToGoal, bool changeableGoal)
    {
        if (landsToGoal > 0 && landsToGoal < _topMats.Length)
        {
            _goalTopState = landsToGoal;
        }

        _canChangeGoalState = changeableGoal;
        ResetTopState();
    }

    /// <summary>
    /// sets the top state to the int passed
    /// </summary>
    /// <param name="state">wich state to set</param>
    private void SetTopState(int state)
    {
        _currentTopState = state;
        if (_currentTopState == _goalTopState)
        {
            _topRenderer.material = _topMats[_topMats.Length -1];
        }
        else
        {
            _topRenderer.material = _topMats[state];
        }
    }

    /// <summary>
    /// sets top state to the next one
    /// </summary>
    private void NextTopState()
    {
        if (IsGoalState() && _canChangeGoalState)
        {
            ResetTopState();
        }
        else if (!IsGoalState())
        {
            SetTopState(_currentTopState + 1);
        }
        ScoreManager.Instance.AddScore(25);
    }

    /// <summary>
    /// sets top state to last state if it isn't on the default state
    /// </summary>
    private void RevertTopState()
    {
        if (_currentTopState > 0)
        {
            SetTopState(_currentTopState - 1);
        }
    }

    /// <summary>
    /// resets the top state to the default state
    /// </summary>
    private void ResetTopState()
    {
        SetTopState(0);
    }

    /// <summary>
    /// Checks if the top state is at the goal state
    /// </summary>
    /// <returns>true if it is at the goal state</returns>
    public bool IsGoalState()
    {
        return (_currentTopState == _goalTopState);
    }

    /// <summary>
    /// on trigger enter:
    /// If player lands: call next state
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!_spawnCube || !other.gameObject.GetComponent<PlayerSpawnScript>().justSpawned)
            {
                NextTopState();
            }
        }
        if (other.gameObject.tag == "SamSlick")
        {
            RevertTopState();
        }
    }
}
