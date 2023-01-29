namespace ProcgenGame.Core.Input;

/// <summary>
/// Represents a notification that is sent when an input action is requested.
/// </summary>
/// <typeparam name="T">Specifies the focal type of the notification.</typeparam>
internal sealed class InputNotification<T> : INotification
{
    public InputAction RequestedAction { get; set; }
    public InputNotification(InputAction requestedAction) =>
        RequestedAction = requestedAction;
}