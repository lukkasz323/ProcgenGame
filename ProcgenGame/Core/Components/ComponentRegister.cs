namespace ProcgenGame.Core.Components;

/// <summary> Registers components for update systems. </summary>
public class ComponentRegister
{
    readonly Dictionary<Type, List<Component>> _componentCollections = new();
    readonly IEnumerable<Type> _allComponentTypes;

    public ComponentRegister()
    {
        _allComponentTypes = typeof(ComponentRegister).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Component)));
        //_allComponentTypes = typeof(ComponentRegister).Assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(Component)));

        foreach (Type type in _allComponentTypes)
        {
            _componentCollections.Add(type, new());
        }
    }

    public List<T> GetComponentCollection<T>()
      where T : Component
    {
        var result = new List<T>();
        foreach (Component component in _componentCollections[typeof(T)])
        {
            result.Add((T)component);
        }
        return result;
    }

    public void RegisterComponent<T>(T component)
        where T : Component
    {
        GetComponentCollection<T>().Add(component);
    }
}