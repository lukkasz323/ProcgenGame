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

    public Entity SpawnPlayer(Vector2 position = new Vector2())
    {
        var entity = new Entity(_entityRegister, _componentRegister);

        entity.AddComponent(new TransformComponent() { Position = position, Size = 32 });
        entity.AddComponent(new PhysicsComponent() { Speed = 100 });
        entity.AddComponent(new CollisionComponent() { IsSolid = true }); 
        entity.AddComponent(new DrawComponent() { Color = Color.Red });

        return entity;
    }
}