using ProcgenGame.Core.Components;

namespace ProcgenGame.Core.Entities;

class Entity
{
    readonly int _id = GlobalState.AutoId();
    readonly List<Component> _components = new();
    readonly EntityRegister _entityRegister;
    readonly ComponentRegister _componentRegister;

    internal Entity(EntityRegister entityRegister, ComponentRegister componentRegister)
    {
        _entityRegister = entityRegister;
        _componentRegister = componentRegister;
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