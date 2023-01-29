namespace ProcgenGame.Core.Input;

/// <summary>
/// Represents a notification that is sent when an input action is requested.
/// </summary>
/// <typeparam name="T">Specifies the focal type of the notification.</typeparam>
internal sealed class InputNotification<T> : INotification
{
    /// <summary>
    /// The <see cref="InputAction"/> that was requested.
    /// </summary>
    internal InputAction RequestedAction { get; set; }
    /// <summary>
    /// Creates a new <see cref="InputNotification{T}"/> instance.
    /// </summary>
    /// <param name="requestedAction">The <see cref="InputAction"/> that was requested.</param>
    internal InputNotification(InputAction requestedAction) =>
        RequestedAction = requestedAction;
}