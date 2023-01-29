using ProcgenGame.Core.Components;

namespace ProcgenGame.Core;

/// <summary> Registers components for update systems. </summary>
public class ComponentRegister
{
    readonly Dictionary<Type, IList> _componentCollections = new()
    {
        { typeof(DrawComponent), new List<DrawComponent>() },
        { typeof(TransformComponent), new List<TransformComponent>() },
        { typeof(PhysicsComponent), new List<PhysicsComponent>() },
    };

    public ComponentRegister()
    {
        //_componentCollections.Add(typeof(DrawComponent), new List<DrawComponent>());
        //_componentCollections.Add(typeof(TransformComponent), new List<TransformComponent>());
        //_componentCollections.Add(typeof(PhysicsComponent), new List<PhysicsComponent>());
    }

    public List<T> GetComponentsOfType<T>()
        where T : Component
    {
        return (List<T>)_componentCollections[typeof(T)];
    }

    public void RegisterComponent<T>(T component)
        where T : Component
    {
        _componentCollections[typeof(T)].Add(component);
    }
}