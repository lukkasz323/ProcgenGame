using ProcgenGame.Core.Input;

namespace ProcgenGame.Core.Rendering;

/// <summary>
/// Represents a notification handler that handles input actions for the <see cref="Game"/> instance.
/// </summary>
internal sealed class RenderingInputHandler : INotificationHandler<InputNotification<RenderingProcessor>>
{
    private readonly GraphicsDeviceManager _graphicsDeviceManager;
    /// <summary>
    /// Creates a new <see cref="GameInputHandler"/> instance.
    /// </summary>
    /// <param name="graphicsDeviceManager">The <see cref="GraphicsDeviceManager"/> to handle input requests for.</param>
    public RenderingInputHandler(GraphicsDeviceManager graphicsDeviceManager) =>
        _graphicsDeviceManager = graphicsDeviceManager;
    /// <summary>
    /// Handles the input notification.
    /// </summary>
    /// <param name="notification">The notification of input for the graphics device .</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for cancelling the operation.</param>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public Task Handle(InputNotification<RenderingProcessor> notification, CancellationToken cancellationToken)
    {
        if (notification.RequestedAction == InputAction.ToggleFullscreen)
            _graphicsDeviceManager.ToggleFullScreen();

        return Task.CompletedTask;
    }
}
