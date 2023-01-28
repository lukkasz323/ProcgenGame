namespace ProcgenGame.Core;

/// <summary>
/// Represents an <see cref="IHostedService"/> that runs <see cref="Game1"/>.
/// </summary>
public class GameService : IHostedService
{
    private readonly Game _game;
    private readonly IHostApplicationLifetime _applicationLifetime;
    /// <summary>
    /// Creates a new <see cref="GameService"/> instance.
    /// </summary>
    /// <param name="game">The game to run.</param>
    public GameService(Game game, IHostApplicationLifetime applicationLifetime) {
        _game = game;
        _applicationLifetime = applicationLifetime;
    }
    /// <summary>
    /// Wires up support for starting the game.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for cancelling the operation.</param>
    /// <returns>A <see cref="Task"/> which defines the state of the operation.</returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _applicationLifetime.ApplicationStarted.Register(HandleServiceStart);
        _game.Exiting += HandleGameExiting;
        return Task.CompletedTask;
    }
    /// <summary>
    /// Stops the game.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for cancelling the operation.</param>
    /// <returns>A <see cref="Task"/> which defines the state of the operation.</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _applicationLifetime.StopApplication();
        return Task.CompletedTask;
    }
    /// <summary>
    /// Handles the game exiting event to ensure the service stops properly.
    /// </summary>
    private void HandleGameExiting(object sender, EventArgs e) =>
        StopAsync(new CancellationToken());
    /// <summary>
    /// Handles the startup of the service and starts the game.
    /// </summary>
    private void HandleServiceStart() =>
        _game.Run();
}