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
    public Dictionary<KeybindAction, IEnumerable<Keys>> Bindings { get; set; }
    /// <summary>
    /// Creates a new <see cref="InputOptions"/> instance with the default configuration.
    /// </summary>
    public InputOptions()
    {
        Bindings = new Dictionary<KeybindAction, IEnumerable<Keys>> {
            { KeybindAction.Close, new Keys[] { Keys.Escape } },
            { KeybindAction.ToggleFullscreen, new Keys[] { Keys.LeftAlt, Keys.Enter } },
            { KeybindAction.MoveUp, new Keys[] { Keys.W } },
            { KeybindAction.MoveDown, new Keys[] { Keys.S } },
            { KeybindAction.MoveLeft, new Keys[] { Keys.A } },
            { KeybindAction.MoveRight, new Keys[] { Keys.D } }
        };
    }
}