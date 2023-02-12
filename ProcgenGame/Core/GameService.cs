using System.Threading.Tasks;

namespace ProcgenGame.Core;

/// <summary>
/// An <see cref="IHostedService"/> which runs a <see cref="Game"/>.
/// </summary>
/// <typeparam name="T">Specifies the concrete <see cref="Game"/> implementation this service is responsible for.</typeparam>
internal sealed class GameService<T> : IHostedService where T : Game
{
    private readonly T _game;
    private readonly IHostApplicationLifetime _applicationLifetime;
    /// <summary>
    /// Creates a new <see cref="GameService"/> instance.
    /// </summary>
    /// <param name="game">The game to run.</param>
    public GameService(T game, IHostApplicationLifetime applicationLifetime) {
        _game = game;
        _applicationLifetime = applicationLifetime;
    }
    /// <summary>
    /// Starts the game.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for cancelling the operation.</param>
    /// <returns>A <see cref="Task"/> which defines the state of the operation.</returns>
	public Task StartAsync(CancellationToken cancellationToken) {
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
    private void HandleGameExiting(object? sender, EventArgs e) =>
        StopAsync(new CancellationToken());
    private void HandleServiceStart() =>
        _game.Run();
}