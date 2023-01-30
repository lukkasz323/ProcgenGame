namespace ProcgenGame.Core.Entities;

sealed class EntityRegister
{
    readonly Dictionary<int, Entity> _entitiesById = new();

    public Entity GetEntity(int id) => _entitiesById[id];

    public void AddEntity(Entity entity) => _entitiesById.Add(GlobalState.AutoId(), entity);
}