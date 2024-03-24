using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [03/23/2024]
 * [Sets up and handles the states for movement]
 */

public class SnakeMoveScript : MonoBehaviour
{
    private BaseHopScript _hopScript;
    private bool _inEggState = true;

    [SerializeField] private GameObject _eggModel;
    [SerializeField] private GameObject _snakeModel;

    private ISnakeState _eggState, _hatchedState;

    private SnakeStateContext _snakeStateContext;

    private void Start()
    {
        _hopScript = gameObject.GetComponent<BaseHopScript>();

        _snakeStateContext = new SnakeStateContext(this);

        _eggState = gameObject.GetComponent<EggState>();
        _hatchedState = gameObject.GetComponent<HatchedState>();

        _snakeStateContext.Transition(_eggState);
    }

    public void Hatch()
    {
        _inEggState = false;
        _eggModel.SetActive(false);
        _snakeModel.SetActive(true);
        _hopScript.ChangeSpeed(2);
        _hopScript.ChangeModel(_snakeModel);
        _snakeStateContext.Transition(_hatchedState);
    }

    public BaseHopScript hopScript
    {
        get { return _hopScript; }
    }

    public bool inEggState
    {
        get { return _inEggState; }
    }
}
