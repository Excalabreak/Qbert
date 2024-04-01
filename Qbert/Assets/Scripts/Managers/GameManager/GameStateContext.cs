
/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [state condext for game manager]
 */

public class GameStateContext
{
    /// <summary>
    /// current state of game manager
    /// </summary>
    public IGameState CurrentState
    {
        get; set;
    }

    //game manager
    private readonly GameManager _gameManager;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="gameManager"></param>
    public GameStateContext(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    /// <summary>
    /// handles current state
    /// </summary>
    public void Transition()
    {
        CurrentState.Handle(_gameManager);
    }


    public void Transition(IGameState state)
    {
        CurrentState = state;
        CurrentState.Handle(_gameManager);
    }
}
