using Microsoft.Xna.Framework.Input;
using ProcgenGame.Core.Rendering;

namespace ProcgenGame.Core.Input;

#nullable enable

/// <summary>
/// Represents an <see cref="IFrameProcessor"/> that handles player input.
/// </summary>
public class InputProcessor : IFrameProcessor
{
    private readonly IMediator _mediator;
    private readonly InputOptions _options;
    private readonly Dictionary<InputAction, bool> _actionLocks;
    /// <summary>
    /// Creates a new <see cref="InputProcessor"/> instance.
    /// </summary>
    /// <param name="options">The <see cref="InputOptions"/> utilized to configure the instance.</param>
    /// <param name="game">The <see cref="Game"/> instance that should be utilized to handle exit requests.</param>
    /// <param name="graphics">The <see cref="GraphicsDeviceManager"/> instance that should be utilized to handle fullscreen requests.</param>
    public InputProcessor(InputOptions options, IMediator mediator)
    {
        _options = options;
        _mediator = mediator;
        _actionLocks = new Dictionary<InputAction, bool>();
        foreach (InputAction action in Enum.GetValues<InputAction>())
            _ = _actionLocks.TryAdd(action, false);
    }
    /// <inheritdoc/>
    public void Process(GameTime gameTime)
    {
        // Determine if an action is requested by the user's input.
        if (!TryDetermineAction(out InputAction? requestedAction))
            return;

        // If the requested action is already being handled, ignore the request.
        InputAction action = requestedAction ?? throw new InvalidOperationException("The requested action was null.");
        if (_actionLocks[action])
            return;

        // Handle the requested action.
        if (!TryCreateInputNotification(action, out INotification? requestedNotification))
            return;

        // Publish the notification.
        INotification notification = requestedNotification ?? throw new InvalidOperationException("The requested notification was null.");
        _ = _mediator.Publish(notification, CancellationToken.None);
    }
    /// <summary>
    /// Attempts to determine the action that should be performed based on the pressed keys.
    /// </summary>
    /// <param name="pressedKeys">The keys currently being pressed by the user.</param>
    /// <param name="requestedAction"></param>
    /// <returns></returns>
    private bool TryDetermineAction([NotNullWhen(true)] out InputAction? requestedAction)
    {
        KeyboardState keyboard = Keyboard.GetState();
        Keys[] pressedKeys = keyboard.GetPressedKeys();
        foreach ((InputAction action, IEnumerable<Keys> keys) in _options.Bindings)
        {
            if (pressedKeys.All(keys.Contains))
            {
                requestedAction = action;
                return true;
            }
        }

        requestedAction = null;
        return false;
    }
    private bool TryCreateInputNotification(InputAction action, [NotNullWhen(true)]  out INotification? notification)
    {
        try
        {
            // Lock the requested action.
            _actionLocks[action] = false;

            // Handle special actions.
            switch (action)
            {
                case InputAction.Close: notification = new InputNotification<Game>(action); return true;
                case InputAction.ToggleFullscreen: notification = new InputNotification<RenderingProcessor>(action); return true;
            }

            // TODO: Handle player interactions.

        } finally
        {
            _actionLocks[action] = false;
        }

        notification = null;
        return false;
    }
}