using ProcgenGame.Core.Entities;

namespace ProcgenGame.Core;

public class EntityManager
{
    readonly Dictionary<int, Entity> _entitiesById = new();

    public Entity GetEntity(int id) => _entitiesById[id];

    public void AddEntity(Entity entity) => _entitiesById.Add(GlobalState.AutoId(), entity);

    public void SetPosition()
    {
        throw new NotImplementedException();
    }
}