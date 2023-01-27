using ProcgenGame.Core.Components;

namespace ProcgenGame.Core.Entities;

public class Entity
{
    private readonly int _id = GlobalState.AutoId();
    private readonly List<Component> _components = new();
    private readonly ComponentRegister _componentRegister;

    public Entity(ComponentRegister componentManager)
    {
        _componentRegister = componentManager;
    }

    public T GetComponent<T>()
        where T : Component
    {
        foreach (T component in _components)
        {
            if (component.GetType() == typeof(T))
            {
                return component;
            }
        }
        throw new InvalidOperationException($"Required item was not found.");
    }

    public void AddComponent<T>()
        where T : Component, new()
    {
        T component = new();
        component.EntityId = _id;
        _components.Add(component);
        _componentRegister.RegisterComponent(component);
    }
}