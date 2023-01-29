using Microsoft.Xna.Framework.Input;

namespace ProcgenGame.Core.Input;

/// <summary>
/// Represents the options for the input system.
/// </summary>
public class InputOptions
{
    /// <summary>
    /// The bindings of keys to actions in the game.
    /// </summary>
    public Dictionary<InputAction, IEnumerable<Keys>> Bindings { get; set; }
    /// <summary>
    /// Creates a new <see cref="InputOptions"/> instance with the default configuration.
    /// </summary>
    public InputOptions()
    {
        Bindings = new Dictionary<InputAction, IEnumerable<Keys>> {
            { InputAction.Close, new Keys[] { Keys.Escape } },
            { InputAction.ToggleFullscreen, new Keys[] { Keys.LeftAlt, Keys.Enter } },
            { InputAction.MoveUp, new Keys[] { Keys.W } },
            { InputAction.MoveDown, new Keys[] { Keys.S } },
            { InputAction.MoveLeft, new Keys[] { Keys.A } },
            { InputAction.MoveRight, new Keys[] { Keys.D } }
        };
    }
}