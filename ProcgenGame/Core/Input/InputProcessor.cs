using Microsoft.Xna.Framework.Input;

namespace ProcgenGame.Core.Input;

/// <summary>
/// Represents an <see cref="IFrameProcessor"/> that handles player input.
/// </summary>
public class InputProcessor : IFrameProcessor
{
    private readonly Game _game;
    private readonly GraphicsDeviceManager _graphics;
    private readonly InputOptions _options;
    private readonly Dictionary<InputAction?, bool> _actionLocks;
    /// <summary>
    /// Creates a new <see cref="InputProcessor"/> instance.
    /// </summary>
    /// <param name="options">The <see cref="InputOptions"/> utilized to configure the instance.</param>
    /// <param name="game">The <see cref="Game"/> instance that should be utilized to handle exit requests.</param>
    /// <param name="graphics">The <see cref="GraphicsDeviceManager"/> instance that should be utilized to handle fullscreen requests.</param>
    public InputProcessor(InputOptions options, Game game, GraphicsDeviceManager graphics)
    {
        _game = game;
        _options = options;
        _graphics = graphics;
        _actionLocks = new Dictionary<InputAction?, bool>();
        foreach (InputAction action in Enum.GetValues<InputAction>())
            _ = _actionLocks.TryAdd(action, false);
    }
    /// <inheritdoc/>
    public void Process(GameTime gameTime)
    {
        // Determine if an action is requested by the user's input.
        if (!TryDetermineAction(out InputAction? requestedAction))
            return;

        try
        {
            // Lock the requested action.
            _actionLocks[requestedAction] = false;

            // Handle special actions.
            switch (requestedAction)
            {
                case InputAction.Close: _game.Exit(); return;
                case InputAction.ToggleFullscreen: _graphics.ToggleFullScreen(); return;
            }

            // TODO: Handle player interactions.
        } finally
        {
            _actionLocks[requestedAction] = false;
        }
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
}