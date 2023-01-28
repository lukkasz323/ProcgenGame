namespace ProcgenGame.Core.Input;

/// <summary>
/// Represents a keybinding in the game.
/// </summary>
public enum KeybindAction
{
    /// <summary>
    /// Use the keybind to close the game.
    /// </summary>
    Close,
    /// <summary>
    /// Use the keybind to toggle fullscreen mode.
    /// </summary>
    ToggleFullscreen,
    /// <summary>
    /// Use the keybind to move the player up.
    /// </summary>
    MoveUp,
    /// <summary>
    /// Use the keybind to move the player down.
    /// </summary>
    MoveDown,
    /// <summary>
    /// Use the keybind to move the player left.
    /// </summary>
    MoveLeft,
    /// <summary>
    /// Use the keybind to move the player right.
    /// </summary>
    MoveRight
}