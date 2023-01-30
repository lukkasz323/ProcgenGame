namespace ProcgenGame.Core.Components;

/// <summary> Registers components for update systems to use. </summary>
sealed class ComponentRegister
{
    readonly Dictionary<Type, IDictionary> _componentCollections = new()
    {
        { typeof(TransformComponent), new Dictionary<int, TransformComponent>() },
        { typeof(PhysicsComponent), new Dictionary<int, PhysicsComponent>() },
        { typeof(DrawComponent), new Dictionary<int, DrawComponent>() },
    };

    public Dictionary<int, T> GetComponentsOfType<T>()
        where T : Component
    {
        return (Dictionary<int, T>)_componentCollections[typeof(T)];
    }

    public void RegisterComponent<T>(T component)
        where T : Component
    {
        _componentCollections[typeof(T)].Add(component.EntityId, component);
    }
}