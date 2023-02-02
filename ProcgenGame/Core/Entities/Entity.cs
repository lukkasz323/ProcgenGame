using ProcgenGame.Core.Components;

namespace ProcgenGame.Core.Entities;

class Entity
{
    readonly int _id = GlobalState.AutoId();
    readonly List<Component> _components = new();
    readonly EntityRegistry _entityRegistry;
    readonly ComponentRegistry _componentRegister;

    internal Entity(EntityRegistry entityRegistry, ComponentRegistry componentRegistry)
    {
        _entityRegistry = entityRegistry;
        _componentRegister = componentRegistry;
    }

    public T GetComponent<T>()
        where T : Component
    {
        foreach (Component component in _components)
        {
            if (component.GetType() == typeof(T))
            {
                return (T)component;
            }
        }
        throw new InvalidOperationException($"Required item was not found.");
    }

    public void AddComponent<T>(T component)
        where T : notnull, Component
    {
        ArgumentNullException.ThrowIfNull(component);

        component.EntityId = _id;
        _components.Add(component);
        _componentRegister.RegisterComponent(component);
    }
}