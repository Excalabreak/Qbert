/*
 * Author: [Lam, Justin]
 * Last Updated: [03/23/2024]
 * [Interface for what state of the snake]
 */

public interface ISnakeState
{
    /// <summary>
    /// calls to handle movement depending on the state
    /// </summary>
    /// <param name="snakeMoveScript"></param>
    void Handle(SnakeMoveScript snakeMoveScript);
}
