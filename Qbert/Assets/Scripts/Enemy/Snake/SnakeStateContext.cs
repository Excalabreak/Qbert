/*
 * Author: [Lam, Justin]
 * Last Updated: [03/23/2024]
 * [Handles what the current state of the snake is]
 */

public class SnakeStateContext
{
    /// <summary>
    /// current state the snake is in
    /// </summary>
    public ISnakeState CurrentState
    {
        get; set;
    }

    //Move scripts that handles state
    private readonly SnakeMoveScript _snakeMoveScript;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="snakeMoveScript">SnakeMoveScript that is handling states</param>
    public SnakeStateContext(SnakeMoveScript snakeMoveScript)
    {
        _snakeMoveScript = snakeMoveScript;
    }

    /// <summary>
    /// calls Handle of current state
    /// </summary>
    public void Transition()
    {
        CurrentState.Handle(_snakeMoveScript);
    }

    /// <summary>
    /// changes the current state and calls Handle
    /// </summary>
    /// <param name="snakeState">Next state</param>
    public void Transition(ISnakeState snakeState)
    {
        CurrentState = snakeState;
        CurrentState.Handle(_snakeMoveScript);
    }
}
