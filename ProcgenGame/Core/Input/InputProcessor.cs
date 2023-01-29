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
    public InputProcessor(InputOptions options, Game game, GraphicsDeviceManager graphics)
    {
        _game = game;
        _options = options;
        _graphics = graphics;
        _actionLocks = new Dictionary<InputAction?, bool>();
        foreach (InputAction action in Enum.GetValues<InputAction>())
            _ = _actionLocks.TryAdd(action, false);
    }
    public void Process(GameTime gameTime)
    {
        // Get the current keyboard state to handle input.
        KeyboardState keyboard = Keyboard.GetState();
        Keys[] pressedKeys = keyboard.GetPressedKeys();
        if (!TryDetermineAction(pressedKeys, out InputAction? requestedAction))
            return;

        try
        {
            // These are very specific actions.
            switch (requestedAction)
            {
                case InputAction.Close: _game.Exit(); return;
                case InputAction.ToggleFullscreen: _graphics.ToggleFullScreen(); return;
            }

            // TODO: Handle player interactions.
        } finally
        {
            _actionLocks[requestedAction] = true;
        }
    }
    private bool TryDetermineAction(IEnumerable<Keys> pressedKeys, [NotNullWhen(true)] out InputAction? requestedAction)
    {
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