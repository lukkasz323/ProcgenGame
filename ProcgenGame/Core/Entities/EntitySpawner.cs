using ProcgenGame.Core.Components;

namespace ProcgenGame.Core.Entities;

sealed class EntitySpawner
{
    readonly EntityRegistry _entityRegistry;
    readonly ComponentRegistry _componentRegistry;

    internal EntitySpawner(EntityRegistry entityRegistry, ComponentRegistry componentRegistry)
    {
        _entityRegistry = entityRegistry;
        _componentRegistry = componentRegistry;
    }

    public Entity SpawnPlayer(Vector2 position = default)
    {
        var entity = new Entity(_entityRegistry, _componentRegistry);

        entity.AddComponent(new TransformComponent() { Position = position, Size = 32 });
        entity.AddComponent(new PhysicsComponent() { Speed = 300f });
        entity.AddComponent(new CollisionComponent() { IsSolid = true });
        entity.AddComponent(new InputComponent());
        entity.AddComponent(new DrawComponent() { Color = Color.Red });

        return entity;
    }
}