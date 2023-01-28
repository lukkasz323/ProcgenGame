using Microsoft.Xna.Framework.Input;

namespace ProcgenGame.Core.Input;

/// <summary>
/// Represents a keybinding in the game.
/// </summary>
public class Keybind
{
    /// <summary>
    /// The display name for the keybind.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The keys required to activate the keybind.
    /// </summary>
    public IEnumerable<Keys> Keys { get; set; }
    /// <summary>
    /// Creates a new keybind.
    /// </summary>
    /// <param name="name">The display name for the keybind.</param>
    /// <param name="keys">The keys required to activate the keybind.</param>
    public Keybind(string name, params Keys[] keys)
    {
        Name = name;
        Keys = keys;
    }
}