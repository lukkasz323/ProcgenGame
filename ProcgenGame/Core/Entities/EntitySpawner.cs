using ProcgenGame.Core.Components;

namespace ProcgenGame.Core.Entities;

sealed class EntitySpawner
{
    readonly EntityRegister _entityRegister;
    readonly ComponentRegister _componentRegister;

    internal EntitySpawner(EntityRegister entityRegister, ComponentRegister componentRegister)
    {
        _entityRegister = entityRegister;
        _componentRegister = componentRegister;
    }

    public Entity SpawnPlayer()
    {
        var entity = new Entity(_entityRegister, _componentRegister);

        entity.AddComponent(new TransformComponent() { Size = 32 });
        entity.AddComponent(new PhysicsComponent());
        entity.AddComponent(new DrawComponent());

        return entity;
    }
}