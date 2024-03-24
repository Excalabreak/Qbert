using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchedState : MonoBehaviour, ISnakeState
{
    private SnakeMoveScript _snakeMoveScript;

    public void Handle(SnakeMoveScript snakeMoveScript)
    {
        if (!_snakeMoveScript)
        {
            _snakeMoveScript = snakeMoveScript;
        }

        Debug.Log("Blah");
    }
}
