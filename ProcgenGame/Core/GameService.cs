namespace ProcgenGame.Core;

/// <summary>
/// Represents an <see cref="IHostedService"/> that runs <see cref="Game1"/>.
/// </summary>
public class GameService : IHostedService
{
    private readonly Game1 _game;
    /// <summary>
    /// Creates a new <see cref="GameService"/> instance.
    /// </summary>
    /// <param name="game">The game to run.</param>
    public GameService(Game1 game) =>
        _game = game;
    /// <summary>
    /// Starts the game.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for cancelling the operation.</param>
    /// <returns>A <see cref="Task"/> which defines the state of the operation.</returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _game.Run();
        return Task.CompletedTask;
    }
    /// <summary>
    /// Stops the game.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for cancelling the operation.</param>
    /// <returns>A <see cref="Task"/> which defines the state of the operation.</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _game.Exit();
        return Task.CompletedTask;
    }
}