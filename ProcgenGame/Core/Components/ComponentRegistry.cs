namespace ProcgenGame.Core.Components;

/// <summary> Registers components for update systems to use. </summary>
sealed class ComponentRegistry
{
    readonly Dictionary<Type, IDictionary> _componentCollections = new();

    public ComponentRegistry()
    {
        //Dictionary<Type, IDictionary> _componentCollections = new();
        var allComponentTypes = typeof(ComponentRegistry).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Component)));
        foreach (Type type in allComponentTypes)
        {
            var collection = (IDictionary)Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(typeof(int), type))!;
            _componentCollections.Add(type, collection);
        }
    }

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

    //List<T> CreateComponentCollection<T>(T component)
    //    where T : Component
    //{

    //}
}