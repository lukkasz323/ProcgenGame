using ProcgenGame.Core.Components;

namespace ProcgenGame.Core.Entities;

class Entity
{
    readonly int _id = GlobalState.AutoId();
    readonly List<Component> _components = new();
    readonly ComponentRegister _componentRegister;

    public Entity(ComponentRegister componentManager)
    {
        _componentRegister = componentManager;
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

    public void AddComponent<T>()
        where T : Component, new()
    {
        var component = new T();
        component.EntityId = _id;
        _components.Add(component);
        _componentRegister.RegisterComponent(component);
    }
}