using ProcgenGame.Core.Input;

namespace ProcgenGame.Core;

/// <summary>
/// Represents a notification handler that handles input actions for the <see cref="Game"/> instance.
/// </summary>
internal sealed class GameInputHandler : INotificationHandler<InputNotification<Game>>
{
    private readonly Game _game;
    /// <summary>
    /// Creates a new <see cref="GameInputHandler"/> instance.
    /// </summary>
    /// <param name="game">The <see cref="Game"/> to handle input requests for.</param>
    public GameInputHandler(Game game) =>
        _game = game;
    /// <summary>
    /// Handles the input notification.
    /// </summary>
    /// <param name="notification">The notification of input for the game.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for cancelling the operation.</param>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public Task Handle(InputNotification<Game> notification, CancellationToken cancellationToken)
    {
        if (notification.RequestedAction == InputAction.Close)
            _game.Exit();

        return Task.CompletedTask;
    }
}
